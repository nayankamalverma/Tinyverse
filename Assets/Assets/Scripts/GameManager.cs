using Assets.Scripts.Events;
using Assets.Scripts.Player;
using Assets.Scripts.UI;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        #region Reference
        //player service
        [SerializeField] private PlayerSO playerSO;
        [SerializeField] private Transform spawnPosition;
        #endregion

        #region Services
        [SerializeField] private CameraController CameraController;
        [SerializeField]private UIService UIService;
        
        private EventService EventService;
        private PlayerService PlayerService;
        #endregion

        private void Start(){
            EventService = new EventService();
            PlayerService = new PlayerService(playerSO, spawnPosition, CameraController, EventService);
            
            UIService.SetServices(EventService);
        }
    }
}