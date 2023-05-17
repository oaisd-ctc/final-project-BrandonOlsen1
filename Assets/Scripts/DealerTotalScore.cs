using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DealerTotalScore : MonoBehaviour
{
  public static int dealerscoreValue;
    Text dealerscore;
    

    void Start()
    {
        dealerscore = GetComponent<Text> ();
         
    }


    void Update ()
    {
        
        dealerscore.text = "Dealer Score is: " + dealerscoreValue ;
    }
}
