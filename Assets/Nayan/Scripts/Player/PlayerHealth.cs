using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float initalHealth = 3;
    [SerializeField] private Animator animator;
    public float currentHealth { get; private set; }

    private void Awake()
    {
        currentHealth = initalHealth;
    }

    public void TakeDamge(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, initalHealth);
        if (currentHealth > 0) {
            //hurt sound 
        }
        else
        {
            animator.SetBool("dead",true);
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            //change scene to lose
            //player dead
        }
    }

    public void Update() {
        
    }
}
