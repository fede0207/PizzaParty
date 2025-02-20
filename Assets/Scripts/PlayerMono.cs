using UnityEngine;

public class PlayerMono : MonoBehaviour
{
    public Player playerData = new Player(); // Istanza della tua classe pura

    // Opzionale: Aggiungi qui metodi per interfacciarti con Unity
    public void AddCardToHand(Card card)
    {
        playerData.Hand.Add(card);
    }
}
