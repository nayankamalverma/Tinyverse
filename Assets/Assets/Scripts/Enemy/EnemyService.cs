using Assets.Scripts.Events;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyService
    {
        private List<EnemyView> enemyList;
        private List<EnemyController> enemyControllerList;
        private Transform playerTransform;
        private EventService eventService;

        public EnemyService(List<EnemyView> enemyList, Transform playerTransform, EventService eventService) { 
            this.enemyList = enemyList;
            this.playerTransform = playerTransform;
            this.eventService = eventService;
            CreateEnemyControllers();
            AddEventListeners();
        }

        public void OnDestroy()
        {
            RemoveEventListeners();
        }

        private void AddEventListeners()
        {
            eventService.OnPlayerDeath.AddListener(OnPlayerDeath);
        }
        private void RemoveEventListeners()
        {
            eventService.OnPlayerDeath.RemoveListener(OnPlayerDeath);
        }

        private void CreateEnemyControllers()
        {
            for(int i = 0; i < enemyList.Count; i++)
            {
                EnemyController enemyController = new EnemyController(enemyList[i],playerTransform, eventService);
            }
        }

        public void OnPlayerDeath()
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].GetController().DisableScript();
            }
        }
    }
}