using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class GameEndMenuUIController:MonoBehaviour
    {
        
        //GameEndMenu
        [SerializeField] private Button restartGame;
        [SerializeField] private Button mainMenu;
        [SerializeField] private TextMeshProUGUI gameResultText;
        private void Awake()
        {
            restartGame.onClick.AddListener(StartGame);
            mainMenu.onClick.AddListener(ActivateMainMenu);
        }
        
        
        private void OnDisable()
        {
            restartGame.onClick.RemoveListener(StartGame);
            mainMenu.onClick.RemoveListener(ActivateMainMenu);
        }
        
        private void StartGame()
        {
        }

        private void ActivateMainMenu()
        {
        }
    }
}