using System.Collections;
using Assets.Scripts.Utilities.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Main
{
    public class SceneService : MonoBehaviour
    {
        [SerializeField] private int MainMenuSceneIndex;
        [SerializeField] private int Level1SceneIndex;
        [SerializeField] private int WinSceneIndex;
        [SerializeField] private int LoseSceneIndex;
        [SerializeField] private float timeToLoadLooseSceene = 2f;

        private EventService eventService;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            eventService = EventService.Instance;
            AddEventListeners();
        }

        private void AddEventListeners()
        {
            eventService.OnPlayButtonClicked.AddListener(LoadGameScene);
            eventService.OnMainMenuButtonClicked.AddListener(LoadMainMenuScreen);
            eventService.OnPlayerDeath.AddListener(OnPlayerDeath);
            eventService.OnPlayerWin.AddListener(LoadGameWinScene);
        }

        private void OnDestroy()
        {
            eventService.OnPlayButtonClicked.RemoveListener(LoadGameScene);
            eventService.OnMainMenuButtonClicked.RemoveListener(LoadMainMenuScreen);
            eventService.OnPlayerDeath.RemoveListener(OnPlayerDeath);
            eventService.OnPlayerWin.RemoveListener(LoadGameWinScene);
        }

        private void OnPlayerDeath()
        {
            StartCoroutine(LooseSceneCoroutine());
        }

        private IEnumerator LooseSceneCoroutine()
        {
            yield return new WaitForSeconds(timeToLoadLooseSceene);
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