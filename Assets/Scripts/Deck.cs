using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    public Suit suit;
    public Rank rank;
    public enum Suit { Clubs, Diamonds, Hearts, Spades }
    public enum Rank { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

    public int GetValue()
    {
        if (rank == Rank.Ace)
        {
            return 14;
        }
        else if (rank == Rank.King)
        {
            return 13;
        }
        else if (rank == Rank.Queen)
        {
            return 12;
        }
        else if (rank == Rank.Jack)
        {
            return 11;
        }
        else
        {
            return (int)rank;
        }
    }





     















}











