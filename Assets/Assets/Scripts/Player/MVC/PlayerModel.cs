using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerModel
    {
        private PlayerSO playerSO;

        public PlayerModel(PlayerSO playerSO)
        {
            this.playerSO = playerSO;
        }

        public GameObject GetThrowablePrefab() => playerSO.throwablePrefab;
        public float GetInitialHealth() => playerSO.initialHealth;
        public float GetPlayerSpeed() => playerSO.speed;
        public float GetGravity() => playerSO.gravity;
        public float GetJumpHeight() => playerSO.jumpHeight;
        public float GetGroundDistance() => playerSO.groundDistance;
        public float GetTurnSmoothTime() => playerSO.turnSmoothTime;
        public float GetCoolDownTime() => playerSO.fireCoolDownTime;
        public float GetShootForce() => playerSO.shootForce;
    }
}