using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileBall : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject,2);
    }
    private void OnCollisionEnter(Collision collision)
    {   if (collision.gameObject.tag == "enemy")
        {
             collision.gameObject.GetComponent<EnemyController>().TakeDamage();
        }
    }
}
