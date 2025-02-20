using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player
{ 
    public List<Card> Hand = new List<Card>(); //carte nella mano
    public List<Card> Collection = new List<Card>(); //carte raccolte
    
    public Card SelectCard()
    {
        if(Hand.Count > 0)
        {
            //logica selezione della carta
            //logica selezione carta IA

            return Hand[0];
            //in questo modo seleziona la prima carta
        }
        return null; //nessuna carta disponibile
    }
}
