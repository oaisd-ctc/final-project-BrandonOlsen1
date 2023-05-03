using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Blackjack : MonoBehaviour
{

    public Sprite[] cardFaces;
    public GameObject cardPrefab;

    public GameObject playingPos;

    public GameObject dealerPos;


    public int playertotal;
    

    public int cardpointcount;









    public static string[] suits = new string[] { "C", "D", "H", "S" };
    public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    public List<string> deck;

    void Start()
    {

        PlayCards();


    }

    void Update()
    {

    }


    public int GetValue(string card)
    {
        int value = 0;

        if (card[1] == '2' || card[1] == '3' || card[1] == '4' || card[1] == '5' || card[1] == '6' || card[1] == '7' || card[1] == '8' || card[1] == '9')
        {
            value += System.Convert.ToInt32(System.Convert.ToString(card[1]));
        }
        else if (card[1] == 'J' || card[1] == 'Q' || card[1] == 'K' || card[1] == 'A')
        {
            switch (card[1])
            {
                // turn jacks value to 10
                case 'J':
                    value += 10;
                    break;
                // turn Queens value to 10
                case 'Q':
                    value += 10;
                    break;

                // turn Kings value to 10
                case 'K':
                    value += 10;
                    break;

                case 'A':
                if (cardpointcount <= 21)
                {
                    value += 11;
                }
                else
                {
                    value += 1;
                }
                    break;
            }

        }
        else
        {
            value += 10;
        }

        return value;
    }


    public void PlayCards()
    {
        deck = GenerateDeck();
        Shuffle(deck);
        BlackjackDeal();


    }



    public static List<string> GenerateDeck()
    {
        List<string> newDeck = new List<string>();
        foreach (string s in suits)
        {
            foreach (string v in values)
            {
                newDeck.Add(s + v);
            }
        }

        return newDeck;
    }



    void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }






    void BlackjackDeal()
    {
        float xOffset = 0f;
        playertotal = 0;
        int playervalueone = 0;
        int playervaluetwo = 0;

        for (int i = 0; i < 4; i++)
        {

            string card = deck[i];
            float positionx = playingPos.transform.position.x;
            float positiony = playingPos.transform.position.y;

            GameObject newCard = Instantiate(cardPrefab, new Vector2(positionx + xOffset, positiony), Quaternion.identity);

            newCard.name = card;

            newCard.GetComponent<Selectable>().faceUp = true;

            GetValue(card);


            if (i < 1)
            {
                GetValue(card);
                playervalueone =+ GetValue(card);
            }
            else if (i > 1 || i < 3)
            {
                GetValue(card);
                playervaluetwo =+ GetValue(card);

                playertotal = playervalueone + playervaluetwo;
                Debug.Log(playertotal);
            }
        
                

            i++;

            if (i <= 2)
            {
                string card1 = deck[i];
                float positionx1 = dealerPos.transform.position.x;
                float positiony1 = dealerPos.transform.position.y;
                GameObject Dealercard = Instantiate(cardPrefab, new Vector2(positionx1 + xOffset, positiony1), Quaternion.identity);

                Dealercard.name = card1;





                Dealercard.GetComponent<Selectable>().faceUp = true;


                xOffset += 0.5f;

                GetValue(card1);

                int DealerValueone = GetValue(card1);
            }

            i++;
        }





    }



    // GameObject newCard = Instantiate(cardPrefab, new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z - zOffset), Quaternion.identity);


}
