using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestructor : MonoBehaviour
{
    [SerializeField] private float destructionDelay = 3f;
    [SerializeField ] private GameObject gameObjectcoin;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            debu();
            StartCoroutine(DestroyAfterDelay());

        }
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destructionDelay);
        Destroy(gameObjectcoin);
    }

    void debu()
    {
        Debug.Log("kdjkjfsd");
    }
}

