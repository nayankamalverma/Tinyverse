using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileBall : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject,3);
    }
    private void OnCollisionEnter(Collision collision)
    {   if (collision.gameObject.tag == "enemy")
            {
                Debug.Log("hit ...");
            }
    }
}
