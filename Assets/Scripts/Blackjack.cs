using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;

public class Blackjack : MonoBehaviour
{
    public Sprite[] cardFaces;
    public GameObject cardPrefab;
    public GameObject playingPos;
    public GameObject dealerPos;
    public GameObject playingPos1;
    private int playertotal;
    public int cardpointcount;
    private int playervalueone;
    private int playervaluetwo;
    private float xOffset;
    private int deckcard;
    private bool hit = false;
    private bool stand = false;
    private float xOffset1;
    private int DealerTotal;
    private int DealerValueone;
    private int total;
    private int value = 0;
    private bool eleven = false;
    public static string[] suits = new string[] { "C", "D", "H", "S" };
    public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    public List<string> deck;



    void Awake()
    {

    }







    void Start()
    {
        deck = GenerateDeck();
        Shuffle(deck);
        BlackjackDeal();
        

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hit = true;
            PlayBlackjackhit();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            stand = true;
            PlayBlackjackstand();
        }
    }

    public int GetValue(string card)
    {

        value = 0;

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
                    eleven = true;
                    value += 11;

                    break;

            }
        }

        else
        {
            value += 10;
        }
        return value;
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







    void BlackjackDeal(){
        xOffset = 0f;
        playertotal = 0;
        playervalueone = 0;
        playervaluetwo = 0;
        DealerTotal = 0;


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
                playervaluetwo =+ +GetValue(card);
                
                playertotal = playervalueone + playervaluetwo;
                PlayerTotal.playerValue += playertotal;

                if (playertotal == 21)
                {
                    print("Blackjack!");
                }
                
                    print(playertotal);
                
            }
            i++;

            if (i <= 2)
            {
                string card2 = deck[i];
                float positionx1 = dealerPos.transform.position.x;
                float positiony1 = dealerPos.transform.position.y;
                GameObject Dealercard = Instantiate(cardPrefab, new Vector2(positionx1 + xOffset, positiony1), Quaternion.identity);

                Dealercard.name = card2;
                Dealercard.GetComponent<Selectable>().faceUp = true;



                GetValue(card2);
                DealerTotal = GetValue(card2);
                DealersAmount.DealerValue += DealerTotal;
                


            }
            xOffset += 0.5f;
            i++;
        }
    }


    void PlayBlackjackstand()
    {


        while (stand == true)
        {
            if (DealerTotal < 17)
            {


                deckcard += 4;
                string card2 = deck[deckcard];
                float positionx1 = dealerPos.transform.position.x;
                float positiony1 = dealerPos.transform.position.y;
                GameObject Dealercard = Instantiate(cardPrefab, new Vector2(positionx1 + xOffset, positiony1), Quaternion.identity);

                Dealercard.name = card2;
                Dealercard.GetComponent<Selectable>().faceUp = true;


                GetValue(card2);
                DealerTotal += GetValue(card2);
                  DealersAmount.DealerValue = DealerTotal;
                





                deckcard += 4;
                xOffset += 1f;

                 if (DealerTotal > 21 && eleven == true)
                {
                    DealerTotal -= 10;
                    eleven = false;
                }


                if (DealerTotal >= 17 && DealerTotal <= 21)
                {   

                    if (DealerTotal > playertotal)
                    {
                        print("Dealer wins and has " + DealerTotal);
                    }
                    else
                    {
                        print("Player wins Dealer has " + DealerTotal);
                    }

                    stand = false;

                }
                
                else if (DealerTotal > 21)
                {
                    print("Player wins Dealer has " + DealerTotal + " compared to the Players " + playertotal);
                    stand = false;
                }

            }
        }
    }



    public void PlayBlackjackhit()
    {

        
        if (playertotal < 21)
        {
            if (hit == true)
            {
                deckcard += 5;
                string card = deck[deckcard];
                float positionx = playingPos1.transform.position.x;
                float positiony = playingPos1.transform.position.y;

                GameObject newCard = Instantiate(cardPrefab, new Vector2(positionx + xOffset1, positiony), Quaternion.identity);
                newCard.name = card;
                newCard.GetComponent<Selectable>().faceUp = true;


                int nextnumber = GetValue(card);


                playertotal += nextnumber;
                PlayerTotal.playerValue = playertotal;

            

                
                
                if (playertotal > 21 && eleven == true)
                {
                    playertotal -= 10;
                    eleven = false;
                }
                 print(playertotal);
                 print("");
            }
            if (playertotal == 21)
            {
                stand = true;
                PlayBlackjackstand();
            }
            else if (playertotal > 21)
            {
                print("Too many!");
                stand = true;
            }
            xOffset1 += 1f;
            deckcard++;
            hit = false;
        }
        
        
    }


























}





















