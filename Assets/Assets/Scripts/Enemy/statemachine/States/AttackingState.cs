using Assets.Scripts.Utilities.Events;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class AttackingState : IState
    {
        private float attackCoolDown;

        public AttackingState(EnemyController controller) : base(controller){}

        public override void Enter()
        {
            controller.enemyView.GetAgent().isStopped = true;
        }

        public override void Update()
        {
            float distance = Vector3.Distance(controller.position, controller.playerTransform.position);
            attackCoolDown -= Time.deltaTime;
            if (attackCoolDown <= 0)
            {
                controller.enemyView.GetAnimator().SetTrigger("attack");
                EventService.Instance.OnPlayerAttacked.Invoke(1);
                attackCoolDown = controller.enemyView.GetAttackSpeed();
            }

            if (distance <= controller.enemyView.GetChaseRadius() && distance >= controller.enemyView.GetAgent().stoppingDistance)
            {
                controller.ChangeState(EnemyState.Chase);
            }
        }
    }
}