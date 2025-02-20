using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardUI : MonoBehaviour
{
    public Image cardImage;
    public Button passButton;

    private Card cardData;
    private PlayerInputController playerInputController;

    public void Setup(Card card, PlayerInputController controller)
    {
        cardData = card;
        playerInputController = controller;

        //imposta l'immagine della carta
        Sprite icon = GetCardSprite(cardData.type);

        //listener bottone
        passButton.onClick.AddListener(() => controller.OnCardPassed(cardData));

        if (cardImage != null && icon != null)
        {
            cardImage.sprite = icon;
        }

    }

    private Sprite GetCardSprite(Card.CardType type)
    {
        switch (type)
        {
            case Card.CardType.Pasta:
                Sprite pastaIcon = Resources.Load<Sprite>("Icons/SpaghettiIcon");
                if (pastaIcon == null) Debug.LogError("Icona Pasta non trovata!");
                return pastaIcon;

            case Card.CardType.Pizza:
                Sprite pizzaIcon = Resources.Load<Sprite>("Icons/PizzaIcon");
                if (pizzaIcon == null) Debug.LogError("Icona Pizza non trovata!");
                return pizzaIcon;

            case Card.CardType.Dolce:
                Sprite dolceIcon = Resources.Load<Sprite>("Icons/TiramisuIcon");
                if (dolceIcon == null) Debug.LogError("Icona Dolce non trovata!");
                return dolceIcon;

            case Card.CardType.Vino:
                Sprite vinoIcon = Resources.Load<Sprite>("Icons/WineIcon");
                if (vinoIcon == null) Debug.LogError("Icona Vino non trovata!");
                return vinoIcon;

            default:
                return null;
        }


    }
}
