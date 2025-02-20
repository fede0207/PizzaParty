using System.Collections.Generic;
using UnityEngine;

public class PlayerHandManager : MonoBehaviour
{
    public GameObject cardPrefabObject;
    public Transform handPanel;

    public PlayerInputController playerInputController;
    public void SetupPlayerHand(List<Card> hand)
    {
        if(handPanel == null || cardPrefabObject == null || playerInputController == null)
        {
            Debug.LogError("handPanel, Prefab o InputController non assegnato");
        }

        foreach (Transform child in handPanel.transform)
        {
            Destroy(child.gameObject); // Pulisci le carte precedenti
        }

        foreach (Card card in hand)
        {
            // Istanzia un prefab di carta
            GameObject cardPrefab = Instantiate(cardPrefabObject, handPanel);
            CardUI cardUI = cardPrefab.GetComponent<CardUI>();

            if (cardUI != null)
            {
                cardUI.Setup(card, playerInputController);
                Debug.Log($"Carta aggiunta: {card.cardName}, Posizione: {cardPrefab.transform.position}");
            }
            else
            {
                Debug.LogError("Il prefab delle carte non contiene il componente CardUI!");
            }

        }
    }
}
