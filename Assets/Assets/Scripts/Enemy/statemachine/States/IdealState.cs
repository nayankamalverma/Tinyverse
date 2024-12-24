using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class IdealState : IState
    {
        public IdealState(EnemyController controller) : base(controller) { }

        public override void Enter()
        {
            Debug.Log("ideal");
            controller.enemyView.GetAgent().isStopped = true;
        }

        public override void Update()
        {
            if (Vector3.Distance(controller.position, controller.playerTransform.position) <= controller.enemyView.GetChaseRadius())
            {
                controller.ChangeState(EnemyState.Chase);
            }
        }
    }
}