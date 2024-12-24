using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class AttackingState : IState
    {
        private float attackCoolDown;
        private EventService eventService;

        public AttackingState(EnemyController controller, EventService eventService) : base(controller)
        { 
            this.eventService = eventService;
        }

        public override void Enter()
        {
            Debug.Log("Attack");
            controller.enemyView.GetAgent().isStopped = true;
        }

        public override void Update()
        {
            float distance = Vector3.Distance(controller.position, controller.playerTransform.position);
            attackCoolDown -= Time.deltaTime;
            if (attackCoolDown <= 0)
            {
                controller.enemyView.GetAnimator().SetTrigger("attack");
                eventService.OnPlayerAttacked.Invoke(1);
                attackCoolDown = controller.enemyView.GetAttackSpeed();
            }
            if (distance <= controller.enemyView.GetChaseRadius() && distance >= controller.enemyView.GetAgent().stoppingDistance)
            {
                controller.ChangeState(EnemyState.Chase);
            }
        }

    }
}