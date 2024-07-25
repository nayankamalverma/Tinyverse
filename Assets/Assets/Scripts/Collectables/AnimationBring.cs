using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBring : MonoBehaviour
{
    [SerializeField] GameObject own;
    [SerializeField] GameObject obj1;
    [SerializeField] GameObject obj2;
    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
           // SoundManager.Instance.play(soundplaces.genricPickup);
            Destroy(own);
            Destroy(obj1);
            obj2.SetActive(true);
           
        }
    }

    
}
