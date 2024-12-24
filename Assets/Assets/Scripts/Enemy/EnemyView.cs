using UnityEngine.AI;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent m_Agent;
        [SerializeField] private Animator animator;
        [SerializeField] private float chaseRadius = 8f;
        [SerializeField] private float attackSpeed = 2f;

        private EnemyController controller;

        public void SetController(EnemyController controller)
        {
            this.controller = controller;
        }

        private void Update()
        {
            controller.Update();
        }

        public NavMeshAgent GetAgent() => m_Agent;
        public Animator GetAnimator() => animator;
        public float GetChaseRadius() => chaseRadius;
        public float GetAttackSpeed() => attackSpeed;
        public EnemyController GetController() => controller;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("ball"))
            {
                controller.TakeDamage();
                GameObject.Destroy(collision.gameObject);
            }
        }

    }
}