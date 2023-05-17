using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartGame : MonoBehaviour
{

    public void ResetTheGame()
    {
        PlayerTotal.playerValue = 0;
        DealersAmount.dealerValue = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void BackToLobby()
    {
        SceneManager.LoadScene("PreGameLobby");
    }





}