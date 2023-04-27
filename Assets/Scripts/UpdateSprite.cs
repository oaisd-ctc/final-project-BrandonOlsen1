using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprite : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;
    private SpriteRenderer spriteRenderer;
    private Selectable selectable;
    private Blackjack blackjack;

      void Start()
    {
        List<string> deck = Blackjack.GenerateDeck();
        blackjack = FindObjectOfType<Blackjack>();

        int i = 0;
        foreach (string card in deck)
        {
            if (this.name == card)
            {
                cardFace = blackjack.cardFaces[i];
                break;
            }
        i++;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        selectable = GetComponent<Selectable>();
    }


    void Update()
    {
        if (selectable.faceUp == true)
        {
            spriteRenderer.sprite = cardFace;
        }
        else 
        {
            spriteRenderer.sprite = cardBack;
        }


    }
}
