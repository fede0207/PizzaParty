using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DraftSystem : MonoBehaviour
{
    public List<PlayerMono> players;
    public DeckManager deck;
    public PlayerHandManager playerHandManager;

    private int currentPlayerIndex = 0;

    public void StartDraft()
    {
        foreach (PlayerMono player in players) //libera la mano e le carte utilizzate di ogni giocatore
        {
            player.playerData.Hand.Clear();
            player.playerData.Collection.Clear();
        }

        foreach (PlayerMono player in players) //distribuisce cinque carte per giocatore
        {
            for (int i = 0; i < 5; i++)
            {
                Card drawnCard = deck.DrawCard();
                if (drawnCard != null)
                {
                    player.playerData.Hand.Add(drawnCard);
                    Debug.Log($"Carta distribuita a {player}: {drawnCard.cardName}");
                }
            }
        }
    }

    public void NextTurn()
    {
        foreach (PlayerMono player in players) //ogni giocatore pesca una carta
        {
            for (int i = 0; i < 5; i++)
            {
                Card drawnCard = deck.DrawCard();
                if (drawnCard != null)
                {
                    player.playerData.Hand.Add(drawnCard);
                    Debug.Log($"Carta distribuita a {player}: {drawnCard.cardName}");
                }
            }
        }

        // Configura la mano del giocatore umano
        Player humanPlayer = players[0].playerData;
        Debug.Log($"Mano del giocatore umano: {string.Join(", ", humanPlayer.Hand.Select(c => c.cardName))}");
        playerHandManager.SetupPlayerHand(humanPlayer.Hand);

        //ogni giocatore sceglie una carta da passare
        for (int i = 0; i < players.Count; i++)
        {
            Player currentPlayer = players[i].playerData;
            Player nextPlayer = players[(i + 1) % players.Count].playerData;

            Card cardToPass = currentPlayer.SelectCard();
            if (cardToPass != null)
            {
                //rimuovi la carta dalla mano
                currentPlayer.Hand.Remove(cardToPass);

                //aggiungi la carta alla mano del player successivo
                nextPlayer.Hand.Add(cardToPass);
            }
        }

        if (deck.cards.Count == 0)
        {
            Debug.LogWarning("Il mazzo è vuoto! Il gioco termina qui.");
            return;
        }

        currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
    }

    void Start()
    {
        StartDraft();
        NextTurn();
    }
}
