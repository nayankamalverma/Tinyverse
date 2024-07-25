using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenShowUP : MonoBehaviour
{
    [SerializeField] Button  Restartlevelbutton;
    [SerializeField] Button  menubutton;
    
    void Start()
    {
        Restartlevelbutton.onClick.AddListener(RestartLevel);
        menubutton.onClick.AddListener(GoToMenu);
    }

   
    // Function to restart the current level
    public void RestartLevel()
    {
        SoundManager.Instance.play(soundplaces.Button);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Function to go to the menu scene
    public void GoToMenu()
    {
        SoundManager.Instance.play(soundplaces.Button2);
        SceneManager.LoadScene("MenuScene"); 
    }
}
