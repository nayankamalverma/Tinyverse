using Assets.Scripts.Events;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SceneService : MonoBehaviour
    {
        [SerializeField] private int MainMenuSceneIndex;
        [SerializeField] private int Level1SceneIndex;
        [SerializeField] private int WinSceneIndex;
        [SerializeField] private int LoseSceneIndex;

        EventService eventService;

        public void SetService(EventService eventService)
        {
            this.eventService = eventService;
            AddEventListeners();
        }

        private void AddEventListeners()
        {
            eventService.OnPlayerDeath.AddListener(OnPlayerDeath);
        }

        private void OnDestroy()
        {
            eventService.OnPlayerDeath.RemoveListener(OnPlayerDeath);
        }

        private void OnPlayerDeath()
        {
            StartCoroutine(LooseSceneCoroutine());
        }

        private IEnumerator LooseSceneCoroutine()
        {
            yield return new WaitForSeconds(2f);
            LoadGameLooseScene();
        }

        public void LoadMainMenuScreen()
        {
            SceneManager.LoadScene(MainMenuSceneIndex);
        }

        public void LoadGameScene()
        {
            SceneManager.LoadScene(Level1SceneIndex);
        }

        public void LoadGameWinScene()
        {
            SceneManager.LoadScene(WinSceneIndex);
        }

        public void LoadGameLooseScene() 
        {
            SceneManager.LoadScene(LoseSceneIndex);
        }


    }
}