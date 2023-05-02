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


    public string GetValue(string card)
    {

        


        
        
       for (i = 0; i < values.Length; i++)
       {
            
            if (i == 0)
            {
                return 11;
            }

            else if (i > 10)
            {
                return 10;
            }
            
                return (int);

            
         }

        
        return 0;


    }



    





    public void PlayCards()
    {
        deck = GenerateDeck();
        Shuffle(deck);
        BlackjackDeal();
        GetValue();
        
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



        for (int i = 0; i < 4; i++)
        {
            string card = deck[i];
            float positionx = playingPos.transform.position.x;
            float positiony = playingPos.transform.position.y;

            GameObject newCard = Instantiate(cardPrefab, new Vector2(positionx + xOffset, positiony), Quaternion.identity);

            newCard.name = card;
            Debug.Log(card);

            newCard.GetComponent<Selectable>().faceUp = true;

            GetValue(card);
            
        i++;

            string card1 = deck[i];
            float positionx1 = dealerPos.transform.position.x;
            float positiony1 = dealerPos.transform.position.y;
            GameObject Dealercard = Instantiate(cardPrefab, new Vector2(positionx1 + xOffset, positiony1), Quaternion.identity);

            Dealercard.name = card1;

            Dealercard.GetComponent<Selectable>().faceUp = true;
            xOffset += 0.5f;

            GetValue(card1);

        }

        



    }



    // GameObject newCard = Instantiate(cardPrefab, new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z - zOffset), Quaternion.identity);


}
