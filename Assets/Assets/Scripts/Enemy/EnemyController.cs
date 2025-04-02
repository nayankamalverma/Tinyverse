using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyController
    {
        public EnemyView enemyView { get; private set; }
        private EnemyStateMachine stateMachine;
        public Transform playerTransform { get; private set; }
        public Vector3 position => enemyView.transform.position;

        public EnemyController(EnemyView enemyView,Transform playerTransform)
        {
            this.enemyView = enemyView;
            this.playerTransform = playerTransform;
            enemyView.SetController(this);
            CreateStateMachine();
            stateMachine.ChangeState(EnemyState.Idle);
        }

        private void CreateStateMachine()
        {
            stateMachine = new EnemyStateMachine(this);
        }

        public void Update()
        {
            stateMachine.Update();
            if(stateMachine.GetCurrentState() == EnemyState.Chase || stateMachine.GetCurrentState() == EnemyState.Attack)
            {
                FaceTowardsTarget();
            }
        }

        public void FaceTowardsTarget()
        {
            Vector3 dir = (playerTransform.position - enemyView.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
            enemyView.transform.rotation = Quaternion.Slerp(enemyView.transform.rotation, lookRotation, Time.deltaTime * 5);
        }

        public void ChangeState(EnemyState newState)
        {
            stateMachine.ChangeState(newState);
        }

        public void DisableScript()
        {
            enemyView.GetAgent().isStopped = true;
            ChangeState(EnemyState.Idle);
            enemyView.enabled = false;
        }

        public void TakeDamage()
        {
            enemyView.GetAnimator().SetBool("dead", true);
            enemyView.enabled = false;
            Object.Destroy(enemyView.gameObject, 2);
        }
    }
}