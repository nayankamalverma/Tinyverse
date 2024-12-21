using Assets.Scripts.Events;
using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
	public class PlayerController
	{
        private PlayerModel playerModel { get; set; }
        private PlayerView playerView { get; set; }

        private EventService eventService;
        private CameraController camera;
        
        //movement
        private float turnSmoothVelocity;
        private Vector3 velocity;
        private float horizontal;
        private float vertical;
        //health
        private float currentHealth;
        //fire
        private float coolDownTime;
        private float timeBetweenShots;

        private bool readyToShoot;
        private bool isGrounded;
        private bool isAlive;
        private bool walking;

        public PlayerController( PlayerSO playerSO, Transform spawnPosition, CameraController camera, EventService eventService)
		{
            playerModel = new PlayerModel(playerSO);
            playerView = GameObject.Instantiate<PlayerView>(playerSO.playerPrefab, spawnPosition);
            playerView.SetController(this);
            this.camera = camera;
            camera.SetTarget(playerView.transform);
            this.eventService = eventService;
        }

        public void Start()
        {
            currentHealth = playerModel.GetInitialHealth();
            eventService.SetInitialHealth.Invoke(currentHealth);
            coolDownTime = playerModel.GetCoolDownTime();
            
            isAlive = true;
            readyToShoot = true;
            
            LockCursor();
        }

        public void Update()
        {
            timeBetweenShots -= Time.deltaTime;
            if (timeBetweenShots <= 0)
            {
                readyToShoot = true;
                timeBetweenShots = coolDownTime;
            }
            if(Input.GetKeyDown(KeyCode.Mouse0) && readyToShoot) ThrowObject();
            if(isAlive)Movement();
            PlayAnimation();
            
        }

        private void Movement()
        {
            //checking if we hit the ground to reset our falling velocity, otherwise we will fall faster the next time
            isGrounded = Physics.CheckSphere(playerView.GetGroundCheck().position, playerModel.GetGroundDistance(), playerView.GetGroundMAsk() );
 
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
 
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

            if(direction.magnitude >= 0.2f)
            {
                float tragetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.transform.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(playerView.transform.eulerAngles.y, tragetAngle, ref turnSmoothVelocity, playerModel.GetTurnSmoothTime());
                playerView.transform.rotation = Quaternion.Euler(0,angle,0);
            
                Vector3 moveDir = Quaternion.Euler(0f,tragetAngle,0f) * Vector3.forward;
                playerView.GetCharController().Move(moveDir.normalized * (playerModel.GetPlayerSpeed() * Time.deltaTime));
            }
 
 
            //check if the player is on the ground, so he can jump
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                //the equation for jumping
                velocity.y = Mathf.Sqrt(playerModel.GetJumpHeight() * -2f * playerModel.GetGravity());
            }
 
            velocity.y += playerModel.GetGravity() * Time.deltaTime;
 
            playerView.GetCharController().Move(velocity * Time.deltaTime);

        }
        private void PlayAnimation()
        {
            //walk
            playerView.GetAnimator().SetFloat("speed", (Math.Abs(horizontal) + Math.Abs(vertical)) / 2);
            //when jump stop playing walk animation 
            if (!isGrounded) playerView.GetAnimator().SetFloat("speed",0);
        }

        private void ThrowObject()
        {
            playerView.GetAnimator().SetTrigger("attack");
            readyToShoot = false;
        }

        private void TakeDamage(float damage=1)
        {
            currentHealth = Mathf.Clamp(currentHealth - damage, 0, playerModel.GetInitialHealth());
            if(currentHealth>0)
            {  //hurt sound 
                
               // SoundManager.Instance.play();
            }else
            {
                playerView.GetAnimator().SetBool("dead", true);
                camera.enabled = false;
                playerView.enabled = false;
            }
        }
        private void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void UnlockCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } 

    }
}