using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class ChasingState : IState
    {
        private float distance;

        public ChasingState(EnemyController controller) : base(controller) { }

        public override void Enter()
        {
            Debug.Log("Chasing");
            controller.enemyView.GetAgent().isStopped = false;
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

    }
}