using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerService
    {
        private PlayerController playerController;
        private EventService eventService;

        public PlayerService(PlayerSO playerSO, Transform spawnPosition,  CameraController _camera, EventService eventService)
        {
            this.eventService = eventService;
            SpawnPlayer(playerSO, spawnPosition, _camera, eventService);
        }

        private void SpawnPlayer(PlayerSO playerSO, Transform spawnPosition, CameraController _camera, EventService eventService)
        {
            playerController = new PlayerController(playerSO, spawnPosition, _camera, eventService);
        }

        public Transform GetPlayerTransform()
        {
            return playerController.playerView.transform;
        }
    }
}