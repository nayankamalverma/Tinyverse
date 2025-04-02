using Assets.Scripts.Main;
using Assets.Scripts.Utilities.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class MainMenuUIController : MonoBehaviour
    {
        [SerializeField] private Button startGame;
        [SerializeField] private Button infoMenu;
        [SerializeField] private Button closeInfoMenu;
        [SerializeField] private GameObject infoPanel;
 
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
            SoundService.Instance.Play(SoundType.Button);
            EventService.Instance.OnPlayButtonClicked.Invoke();
        }
        private void ActivateInfoPanel()
        {
            SoundService.Instance.Play(SoundType.Button);
            infoPanel.SetActive(true);
        }
        private void DeactivateInfoPanel()
        {
            SoundService.Instance.Play(SoundType.Button);
            infoPanel.SetActive(false);
        }
        private void QuitGame()=>Application.Quit();
    }
    
}