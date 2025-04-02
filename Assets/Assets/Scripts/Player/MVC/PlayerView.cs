using Assets.Scripts.Main;
using Assets.Scripts.Utilities.Events;
using UnityEngine;

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
        public Transform GetAim() => aim;
        public Transform GetGroundCheck() => groundCheck;
        public LayerMask GetGroundMAsk() => groundMask;
        public CharacterController GetCharController() => characterController;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("coins"))
            {
                playerController.OnCoinCollected();
                Destroy(other.gameObject);
            }

            if (other.CompareTag("Key")) // game win logic
            {
                Debug.Log("win");
                SoundService.Instance.Play(SoundType.LevelComplete);
                EventService.Instance.OnPlayerWin.Invoke();
            }
        }

        private void OnDestroy()
        {
            playerController.OnDeath();
        }
    }
}