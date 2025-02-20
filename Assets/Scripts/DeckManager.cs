using UnityEngine;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class DeckManager : MonoBehaviour
{
    public List<Card> cards = new List<Card>();

    public void ShuffleDeck()
    {
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            Card temp = cards[i];
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }

    public Card DrawCard()
    {
        if (cards.Count > 0)
        {
            Card topCard = cards[0];
            cards.RemoveAt(0);
            return topCard;
        }
        return null;
    }

    private void Start()
    {
        Debug.Log("Mescolando il mazzo");
        PrintDeck();

        ShuffleDeck();

        Debug.Log("Il mazzo è stato mescolato");
        PrintDeck();

    }
    
    private void PrintDeck()
    {
        foreach (var card in cards)
        {
            Debug.Log($"Carta: {card.cardName}, Punti: {card.cardPoints}, Tipo: {card.type}");
        }
    }
}


