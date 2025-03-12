using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class MainMenuUIController : MonoBehaviour
    {
        [SerializeField] private Button startGame;
        [SerializeField] private Button infoMenu;
        [SerializeField] private Button closeInfoMenu;
        [SerializeField] private GameObject infoPanel;
        [SerializeField] private int gameSceneIndex;
 
        private void Awake()
        {
            startGame.onClick.AddListener(StartGame);
            infoMenu.onClick.AddListener(ActivateInfoPanel);
            closeInfoMenu.onClick.AddListener(DeactivateInfoPanel);
        }

        private void OnDestroy()
        {
            startGame.onClick.RemoveListener(StartGame);
            infoMenu.onClick.RemoveListener(ActivateInfoPanel);
            closeInfoMenu.onClick.RemoveListener(DeactivateInfoPanel);
        }
        
        private void StartGame()
        {
            SoundManager.Instance.Play(SoundType.Button);
            SceneManager.LoadScene(gameSceneIndex);
        }
        private void ActivateInfoPanel()
        {
            SoundManager.Instance.Play(SoundType.Button);
            infoPanel.SetActive(true);
        }
        private void DeactivateInfoPanel()
        {
            SoundManager.Instance.Play(SoundType.Button);
            infoPanel.SetActive(false);
        }
        private void QuitGame()=>Application.Quit();
    }
    
}