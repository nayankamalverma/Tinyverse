using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoad : MonoBehaviour
{
    [SerializeField] Button playbutton;
    [SerializeField] Button Infobutton;
    [SerializeField] Button menubutton;
   // [SerializeField] Button playbutton;
   // [SerializeField] Button playbutton;

    [SerializeField] int Levelno;
    private void Start()
    {
        playbutton.onClick.AddListener(LoadScenesetup);
        Infobutton.onClick.AddListener(PlaySound);
        menubutton.onClick.AddListener(PlaySound);
    }
    void LoadScenesetup()
    {
        SoundManager.Instance.play(soundplaces.Button);
        SceneManager.LoadScene(Levelno);

    }
    void PlaySound()
    {
        SoundManager.Instance.play(soundplaces.Button2);
    }

}