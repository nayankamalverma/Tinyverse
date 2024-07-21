using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform aim;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.81f * 2;
    [SerializeField] private float jumpHeight = 3f;

    [SerializeField] private float attackRange = 10.0f;
    [SerializeField] private float attackDirLeft = -30.0f;
    [SerializeField] private float attackDirRight = 30.0f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    private Vector3 velocity;

    float horizontal;
    float vertical;
    bool isGrounded;
    bool walking;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Quaternion.Euler(0, attackDirLeft, 0) * aim.forward;
        //raycast for attack 
        Ray rayLeft  = new Ray(aim.position, dir);
        Ray ray = new Ray(aim.position, aim.forward);

        dir = Quaternion.Euler(0, attackDirRight, 0) * aim.forward;
        Ray rayRight= new Ray(aim.position, dir);

        //checking if we hit the ground to reset our falling velocity, otherwise we will fall faster the next time
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
 
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
 
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if(direction.magnitude >= 0.2f)
        {
            float tragetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, tragetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0,angle,0);
            
            Vector3 moveDir = Quaternion.Euler(0f,tragetAngle,0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
 
 
        //check if the player is on the ground so he can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //the equation for jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
 
        velocity.y += gravity * Time.deltaTime;
 
        controller.Move(velocity * Time.deltaTime);

        //attack
        if (Physics.Raycast(rayLeft, out RaycastHit hitforward, attackRange) || Physics.Raycast(ray, out RaycastHit hitleft ) || Physics.Raycast(ray, out RaycastHit hitright))
        {
            // If the ray hits something, do something
           // Debug.Log("Hit: " + hitforward.collider.name);

            // Optionally, you can visualize the ray in the Scene view
            
            Debug.DrawRay(aim.position, aim.forward * attackRange, Color.red);
        }
        else
        {
            dir = Quaternion.Euler(0,- 30, 0) * aim.forward;
            // Visualize the ray in the Scene view when it doesn't hit anything
            Debug.DrawRay(aim.position, dir * attackRange , Color.green);
            dir = Quaternion.Euler(0, 30, 0) * aim.forward;
            Debug.DrawRay(aim.position, dir * attackRange , Color.green);
            Debug.DrawRay(aim.position, aim.forward * attackRange , Color.green);
        }


        playAnimation();
          
    }

    void playAnimation()
    {
        //walk
        animator.SetFloat("speed", (Math.Abs(horizontal) + Math.Abs(vertical)) / 2);
        
        //when jump stop playing walk animation 
        if (!isGrounded) animator.SetFloat("speed",0);
        
    }
}
