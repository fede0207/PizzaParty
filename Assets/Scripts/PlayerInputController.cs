using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public DraftSystem draftSystem;
    public void OnCardPassed(Card cardToPass)
    {

        if (draftSystem == null)
        {
            Debug.LogError("draftSystem non è assegnato!");
            return;
        }
        //ottieni player umano supponendo sia il primo della lista
        Player humanPlayer = draftSystem.players[0].playerData;

        if(!humanPlayer.Hand.Contains(cardToPass))
        {
            Debug.Log("La carta selezionata non è nella mano del giocatore!");
            return;
        }

        humanPlayer.Hand.Remove(cardToPass); //rimuove la carta selezionata dalla mano del giocatore

        //trova il giocatore successivo
        int nextPlayerIndex = (0 + 1) % draftSystem.players.Count;
        Player nextPlayer = draftSystem.players[nextPlayerIndex].playerData;

        nextPlayer.Hand.Add(cardToPass);//aggiunge la carta nella mano del giocatore successivo

        draftSystem.NextTurn();//passa al turno successivo
    }
}
