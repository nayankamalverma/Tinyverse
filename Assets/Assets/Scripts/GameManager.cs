using Assets.Scripts.Enemy;
using Assets.Scripts.Events;
using Assets.Scripts.Player;
using Assets.Scripts.UI;
using System.Collections.Generic;
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
        //enemy service
        [SerializeField] private List<EnemyView> enemyList;
        #endregion

        #region Services
        [SerializeField] private CameraController CameraController;
        [SerializeField]private UIService UIService;
        [SerializeField] private SceneService SceneService;

        private EventService EventService;
        private PlayerService PlayerService;
        private EnemyService EnemyService;
        private CoinService CoinService;
        #endregion

        private void Start(){
            EventService = new EventService();
            PlayerService = new PlayerService(playerSO, spawnPosition, CameraController, EventService);
            EnemyService = new EnemyService(enemyList,PlayerService.GetPlayerTransform(), EventService);
            CoinService = new CoinService(EventService);
            UIService.SetServices(EventService);
            SceneService.SetService(EventService);
        }
        private void OnDestroy()
        {
            EnemyService.OnDestroy();
        }
    }
}