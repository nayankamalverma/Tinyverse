using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent m_Agent;
    [SerializeField] Animator animator;

    [SerializeField] private float lookRadius = 8f;
    [SerializeField] private float attackSpped = 2f;

    private float attckCoolDown;
    Transform player;
    PlayerHealth playerHealth;
    float distance;

    private void Start()
    {
        player = PlayerManager.instance.player.transform;
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        attckCoolDown-=Time.deltaTime;

        distance = Vector3.Distance(player.position, transform.position);
        animator.SetBool("following", false);
        if (distance <= lookRadius)
        {
            if (distance <= m_Agent.stoppingDistance) {
                faceTowardsTarget();
                attack();
            }
            else
            {
                m_Agent.SetDestination(player.position); 
            }
        }
        if(m_Agent.velocity.magnitude > 0.1f)
        animator.SetBool("following", true);
    }

    void attack()
    {
        if (attckCoolDown <= 0) {
            if (distance <= m_Agent.stoppingDistance) {  playerHealth.TakeDamge(1); }
            animator.SetTrigger("attack");
            attckCoolDown = attackSpped;
        }
    }

    void faceTowardsTarget()
    {
    Vector3 dir =  (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x,0,dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
     }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void TakeDamage()
    {
        animator.SetBool("dead", true);
        gameObject.GetComponent<EnemyController>().enabled = false;
        Destroy(gameObject, 2);
    }
}
