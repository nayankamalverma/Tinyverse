using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    [CreateAssetMenu(fileName = "PlayerSO", menuName = "Scriptable Objects/PlayerSO")]
    public class PlayerSO : ScriptableObject
    {
        public PlayerView playerPrefab;
        public GameObject throwablePrefab;
        public float initialHealth = 3;
        public float speed = 12f;
        public float gravity = -9.81f * 2;
        public float jumpHeight = 3f;
        public float groundDistance = 0.4f;
        public float turnSmoothTime = 0.1f;
        public float fireCoolDownTime = 2f;
        public float shootForce = 20f;
    }
}