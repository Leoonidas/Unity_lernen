using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MemoryCard FirstSelectedCard;
    public MemoryCard SecondSelectedCard;


    public void CardClicked(MemoryCard Card)
    {
        if (FirstSelectedCard == null)
        {
            FirstSelectedCard = Card;
            Debug.Log(Card.Identifier);
        }
        else
        {
            SecondSelectedCard = Card;
            Debug.Log(Card.Identifier);

            if (FirstSelectedCard.Identifier == SecondSelectedCard.Identifier)
            {
                Destroy(FirstSelectedCard.gameObject);
                Destroy(SecondSelectedCard.gameObject);
            }

            FirstSelectedCard = null;
            SecondSelectedCard = null;
        }
        
    }
}
