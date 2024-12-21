using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Player
{
    public class PlayerView : MonoBehaviour
    {

        [SerializeField] private Animator animator;
        [SerializeField] private Transform aim;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private CharacterController characterController;

        private PlayerController playerController;

        private void Start()
        {
            playerController.Start();
        }

        private void Update()
        {
            playerController?.Update();
        }

        public void SetController(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        public Animator GetAnimator() => animator;
        public Transform GetGroundCheck() => groundCheck;
        public LayerMask GetGroundMAsk() => groundMask;
        public CharacterController GetCharController() => characterController;
        private void OnDisable()
        {
        }
    }
}