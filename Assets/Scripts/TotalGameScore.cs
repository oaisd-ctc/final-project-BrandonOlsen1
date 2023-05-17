using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalGameScore : MonoBehaviour
{
  public static int playerscoreValue;
    Text playerscore;
    

    void Start()
    {
        playerscore = GetComponent<Text> ();
         
    }


    void Update ()
    {
        
        playerscore.text = "Player Score is: " + playerscoreValue ;
    }
}
