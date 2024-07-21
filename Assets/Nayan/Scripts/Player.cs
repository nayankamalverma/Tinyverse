using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
   
    [SerializeField] Rigidbody rb;
    [SerializeField] float Force = 7;
    [SerializeField] float PlayerSpeed = 5;
    private bool isGrounded = true;
    [SerializeField] Animator animator;
    private float horizontalInput;

    private void Start()
    {
         
        Physics.gravity = new Vector3(0, -7F, 0);
       
    }
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        PlayAnimation();   
        Movecharachter(horizontalInput);
      

    }
   

    private void Movecharachter(float horizontalInput)
    {
        Vector3 position = transform.position;
        if (horizontalInput != 0)
        {
           
            position.x = position.x + horizontalInput * PlayerSpeed * Time.deltaTime;
            transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {


            rb.AddForce(Vector3.up * Force, ForceMode.Impulse);
            animator.SetTrigger("IsJump");
            isGrounded = false;
        }
    }
    void PlayAnimation()
    {
        animator.SetFloat("IsRun", Mathf.Abs(horizontalInput));

        Vector3 scale = transform.localScale;
        if (horizontalInput < 0)
        {
            scale.x = 1 * Mathf.Abs(scale.x);
        }
        else if (horizontalInput > 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}


