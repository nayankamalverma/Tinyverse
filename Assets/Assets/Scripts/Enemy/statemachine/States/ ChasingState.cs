using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class ChasingState : IState
    {
        private float distance;

        public ChasingState(EnemyController controller) : base(controller){}

        public override void Enter()
        {
            controller.enemyView.GetAgent().isStopped = false;
            controller.enemyView.GetAnimator().SetBool("following",true);
        }

        public override void Update()
        {
            controller.enemyView.GetAgent().SetDestination(controller.playerTransform.position);
            distance = Vector3.Distance(controller.position, controller.playerTransform.position);

            if (distance <= controller.enemyView.GetAgent().stoppingDistance)
            {
                controller.ChangeState(EnemyState.Attack);
            }
            else if (distance > controller.enemyView.GetChaseRadius())
            {
                controller.ChangeState(EnemyState.Idle);
            }
        }

        public override void Exit()
        {
            controller.enemyView.GetAnimator().SetBool("following", false);
        }
    }
}