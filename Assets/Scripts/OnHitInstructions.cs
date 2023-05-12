using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;

public class OnHitInstructions : MonoBehaviour
{
    public GameObject Card;
    public GameObject Card2;

    public bool hit = false;
    public bool stand = false;





    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hit = true;
            InstructionHit();

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            stand = true;
            InstructionStand();

        }
    }


    public void InstructionHit()
    {
        if (hit == true)
        {
            GameObject newCard = Instantiate(Card, new Vector2(1.25f, -1.5f), Quaternion.identity);
            print("You have 20 this would be a stand!  Click S to stand");
            hit = false;
        }

    }

    public void InstructionStand()
    {
        if (stand == true)
        {
            GameObject newCard = Instantiate(Card2, new Vector2(.6f, 1.5f), Quaternion.identity);
            print("You WIN Congrats you are ready to play!");
            stand = false;
        }
    }






}
