using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Blackjack : MonoBehaviour
{

    public Sprite[] cardFaces;
    public GameObject cardPrefab;

    public GameObject[] playingPos;

    

    

    
    


   public static string[] suits = new string[] { "C", "D", "H", "S"};
   public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};

   


   

   

   public List<string> deck;

     

     void Start()
    {
        
        PlayCards();
        
        
    }

    void Update() 
    {
        
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
        while (n>1)
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

        
        // float yOffset = 0;
        float zOffset = 0.03f;
        float xOffset = 0.03f;





        foreach (string card in deck)
        {


            for (int i = 0; i < 2; i++)
            {


                
                



                GameObject newCard = Instantiate(cardPrefab, new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z - zOffset), Quaternion.identity);
                newCard.name = card;

                newCard.GetComponent<Selectable>().faceUp = true;

                // yOffset = yOffset + 0.3f;
                xOffset = xOffset + 0.3f;
                zOffset = zOffset + 0.03f;

            }
            break;

        }
    }
    

    



}
