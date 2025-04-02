using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerService
    {
        private PlayerController playerController;

        public PlayerService(PlayerSO playerSO, Transform spawnPosition, CameraController camera)
        {
            playerController = new PlayerController(playerSO, spawnPosition, camera);
        }

        public Transform GetPlayerTransform()
        {
            return playerController.playerView.transform;
        }
    }
}