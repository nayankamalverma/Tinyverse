using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    [SerializeField] GameObject winscreen;
  
    void Start()
    {
        winscreen.SetActive(false);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("sdsfsdfds");

        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAA");
            winscreen.SetActive(true);
        }
    }
}
