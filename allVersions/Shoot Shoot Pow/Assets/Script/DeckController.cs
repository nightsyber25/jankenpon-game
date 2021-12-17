using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    public static DeckController instance;
    public List<Card> cardDeck = new List<Card>();
    public int[] numOfCardInDeck = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    public int cardRandom;
    int cardCount = 0;
    int i = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

        CardRandom();
        PrintDeck();
    }

    public void PrintDeck()
    {
        for (i = 0; i < 9; i++)
        {
            Debug.Log(numOfCardInDeck[i]);
        }
    }

    void Update()
    {

    }
    void cardTypeCount(int cardID)
    {
        switch (cardID)
        {
            case 0:
                numOfCardInDeck[0] += 1;
                break;
            case 1:
                numOfCardInDeck[1] += 1;
                break;
            case 2:
                numOfCardInDeck[2] += 1;
                break;
            case 3:
                numOfCardInDeck[3] += 1;
                break;
            case 4:
                numOfCardInDeck[4] += 1;
                break;
            case 5:
                numOfCardInDeck[5] += 1;
                break;
            case 6:
                numOfCardInDeck[6] += 1;
                break;
            case 7:
                numOfCardInDeck[7] += 1;
                break;
            case 8:
                numOfCardInDeck[8] += 1;
                break;
            default:
                Debug.LogError("Error, Invalid card ID was found");
                break;
        }
    }
    void CardRandom()
    {
        int specialCardCount = 0;
        // Random normal cards
        for (cardCount = 0; cardCount < 40; cardCount++)
        {
            //Random ID in normal cards
            if (specialCardCount < 10)
            {
                cardRandom = Random.Range(1, 9);
                if (cardRandom > 3)
                {
                    specialCardCount++;
                }
            }
            else
            {
                cardRandom = Random.Range(1, 4);
            }
            Card temp = new Card(cardRandom);
            cardDeck.Add(temp);
            cardTypeCount(cardRandom);
            Debug.Log((cardCount + 1) + cardDeck[cardCount].cardName);
        }


    }
}
