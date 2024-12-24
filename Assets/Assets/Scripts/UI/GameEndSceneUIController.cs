using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndSceneUIController : MonoBehaviour
{
    [SerializeField] private Button  RestartGamebutton;
    [SerializeField] private Button  menubutton;
    [SerializeField] private int GameSceneIndex = 1;
    [SerializeField] private int MainMenuSceneIndex = 0;

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
        SoundManager.Instance.Play(SoundType.Button);
        SceneManager.LoadScene(GameSceneIndex);
    }

    public void GoToMenu()
    {
        SoundManager.Instance.Play(SoundType.Button2);
        SceneManager.LoadScene(MainMenuSceneIndex); 
    }
}
