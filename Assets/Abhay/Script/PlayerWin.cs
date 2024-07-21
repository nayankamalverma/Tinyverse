using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour
{
    [SerializeField] GameObject winscreen;

    [SerializeField] int winscene_no;

    
    private void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            SceneManager.LoadScene(winscene_no);
        }
    }
}
