using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MemoryCard FirstSelectedCard;
    public MemoryCard SecondSelectedCard;

    private bool CanClick = true;


    public void CardClicked(MemoryCard Card)
    {
        // Verhindern von Klicken wärend dem Warten auf das Umdrehen
        if (CanClick == false)
        {
            return;
        }



        // Anheben der Karte
        Card.TargetHight = 0.1f;
        // Rotation der Karte
        Card.TargetRoation = 90;


        // Unterscheidung, welche Karte angeklickt wurde und ob ein Paar umgedreht wurde
        if (FirstSelectedCard == null)
        {
            FirstSelectedCard = Card;
            Debug.Log(Card.Identifier);
        }
        else
        {
            SecondSelectedCard = Card;
            Debug.Log(Card.Identifier);

            CanClick = false;

            // Verzögerung der Ausführung von CheckMatch()
            Invoke("CheckMatch", 1);

        }
        
    }

    // Überprüft, ob die zwei ausgewählten Karten ein Paar ergeben
    private void CheckMatch()
    {
        if (FirstSelectedCard.Identifier == SecondSelectedCard.Identifier)
        {
            Destroy(FirstSelectedCard.gameObject);
            Destroy(SecondSelectedCard.gameObject);
        }
        else
        {
            // Wiederumdrehen der Karten
            FirstSelectedCard.TargetRoation = -90;
            SecondSelectedCard.TargetRoation = -90;
            // Absetzen der Karten
            FirstSelectedCard.TargetHight = 0.01f;
            SecondSelectedCard.TargetHight = 0.01f;
        }
        FirstSelectedCard = null;
        SecondSelectedCard = null;

        CanClick = true;
    }
}
