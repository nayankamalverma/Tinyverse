using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoad : MonoBehaviour
{
    [SerializeField] Button playbutton;
    [SerializeField] int Levelno;
    private void Start()
    {
        playbutton.onClick.AddListener(LoadScenesetup);
    }
    void LoadScenesetup()
    {
       // SoundManager.Instance.play(soundplaces.Button);
        SceneManager.LoadScene(Levelno);

    }


}