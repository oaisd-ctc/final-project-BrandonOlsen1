using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DealersAmount : MonoBehaviour
{
    public static int dealerValue = 0;
    Text dealer;

    void Start()
    {
        dealer = GetComponent<Text>();
    }


    void Update()
    {
        dealer.text = "Dealer: " + dealerValue;
    }
}
