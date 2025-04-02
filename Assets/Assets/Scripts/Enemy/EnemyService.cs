using System.Collections.Generic;
using Assets.Scripts.Utilities.Events;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyService
    {
        private List<EnemyView> enemyList;
        private Transform playerTransform;

        public EnemyService(List<EnemyView> enemyList, Transform playerTransform)
        {
            this.enemyList = enemyList;
            this.playerTransform = playerTransform;
            CreateEnemyControllers();
        }

        private void CreateEnemyControllers()
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                EnemyController enemyController = new EnemyController(enemyList[i], playerTransform);
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