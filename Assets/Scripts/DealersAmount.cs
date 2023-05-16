using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DealersAmount : MonoBehaviour
{
    public static int DealerValue = 0;
    Text Dealer;

    void Start()
    {
        Dealer = GetComponent<Text> ();
    }


    void Update ()
    {
        Dealer.text = "Dealer: " + DealerValue;
    }



}
