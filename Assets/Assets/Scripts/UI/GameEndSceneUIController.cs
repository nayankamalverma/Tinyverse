using Assets.Scripts.Main;
using Assets.Scripts.Utilities.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class GameEndSceneUIController : MonoBehaviour
    {
        [SerializeField] private Button RestartGamebutton;
        [SerializeField] private Button menubutton;

        private void Awake()
        {
            RestartGamebutton.onClick.AddListener(RestartGame);
            menubutton.onClick.AddListener(GoToMenu);
        }

        private void OnDestroy()
        {
            RestartGamebutton.onClick.RemoveListener(RestartGame);
            menubutton.onClick.RemoveListener(GoToMenu);
        }

        public void RestartGame()
        {
            SoundService.Instance.Play(SoundType.Button);
            EventService.Instance.OnPlayButtonClicked.Invoke();
        }

        public void GoToMenu()
        {
            SoundService.Instance.Play(SoundType.Button2);
            EventService.Instance.OnMainMenuButtonClicked.Invoke();
        }
    }
}