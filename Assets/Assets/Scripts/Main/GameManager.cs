using Assets.Scripts.Enemy;
using Assets.Scripts.Player;
using Assets.Scripts.UI;
using System.Collections.Generic;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Main
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

        private PlayerService PlayerService;
        private EnemyService EnemyService;
        private CoinService CoinService;
        #endregion

        private void Start(){
            PlayerService = new PlayerService(playerSO, spawnPosition, CameraController);
            EnemyService = new EnemyService(enemyList,PlayerService.GetPlayerTransform());
            CoinService = new CoinService();
        }
    }
}