using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class screenloader : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("GameScene");
    }


    public void LoadHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
