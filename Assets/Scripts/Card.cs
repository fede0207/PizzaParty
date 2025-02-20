using UnityEngine;

[System.Serializable]
public class Card 
{
    public string cardName;
    public int cardPoints;
    public CardType type;

    public virtual void ApplyEffect()
    { 
        //logica per effetti delle carte 
    }

    public enum CardType 
    {
        Pasta,
        Formaggio,
        Pizza,
        Dolce,
        Vino,
        IngredientiSpeciali
    }
}
