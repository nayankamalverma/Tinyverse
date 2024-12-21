using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScene : MonoBehaviour
{
    [SerializeField] Button playbutton;
    [SerializeField] Button M_button;
   

    [SerializeField] int Levelno;
    [SerializeField] int Levelno2;
    private void Start()
    {
        playbutton.onClick.AddListener(LoadScenesetup);
        M_button.onClick.AddListener(PlaySound);
       
    }
    void LoadScenesetup()
    {
       // SoundManager.Instance.play(soundplaces.Button);
        SceneManager.LoadScene(Levelno);

    }
    void PlaySound()
    {
       // SoundManager.Instance.play(soundplaces.Button2);
        SceneManager.LoadScene(Levelno2);
    }

}