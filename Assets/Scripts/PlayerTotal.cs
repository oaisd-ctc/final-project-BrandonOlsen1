using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerTotal : MonoBehaviour
{
    public static int playerValue = 0;
    Text player;

    void Start()
    {
        player = GetComponent<Text> ();
    }


    void Update ()
    {
        player.text = "Player: " + playerValue;
    }














}
