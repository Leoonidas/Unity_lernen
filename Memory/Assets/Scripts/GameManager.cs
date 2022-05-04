using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip ClipCardUp;
    public AudioClip ClipCardDown;
    public AudioClip ClipMatch;

    public GameObject[] AllCards;

    private MemoryCard FirstSelectedCard;
    private MemoryCard SecondSelectedCard;

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

            // ClipCardUp abspielen
            AudioSource.PlayOneShot(ClipCardUp);
        }
        else
        {
            if (Card != FirstSelectedCard)
            {
                SecondSelectedCard = Card;
                Debug.Log(Card.Identifier);

                // ClipCardUp abspielen
                AudioSource.PlayOneShot(ClipCardUp);

                CanClick = false;

                // Verzögerung der Ausführung von CheckMatch()
                Invoke("CheckMatch", 1);
            }
        }
        
    }

    // Überprüft, ob die zwei ausgewählten Karten ein Paar ergeben
    private void CheckMatch()
    {
        if (FirstSelectedCard.Identifier == SecondSelectedCard.Identifier)
        {
            Destroy(FirstSelectedCard.gameObject);
            Destroy(SecondSelectedCard.gameObject);
            // ClipMatch abspielen
            AudioSource.PlayOneShot(ClipMatch);
        }
        else
        {
            // Wiederumdrehen der Karten
            FirstSelectedCard.TargetRoation = -90;
            SecondSelectedCard.TargetRoation = -90;
            // Absetzen der Karten
            FirstSelectedCard.TargetHight = 0.01f;
            SecondSelectedCard.TargetHight = 0.01f;

            // ClipCardDown abspielen
            AudioSource.PlayOneShot(ClipCardDown);
        }
        FirstSelectedCard = null;
        SecondSelectedCard = null;

        CanClick = true;
    }


    private void Awake()
    {
        // Liste mit allen Starrtpositionen
        List<Vector3> AllPositions = new List<Vector3>();

        foreach (GameObject Card in AllCards)
        {
            AllPositions.Add(Card.transform.position);
        }

        // Radomizer
        System.Random rnd = new System.Random();

        // Liste aus Positionen zufällig mischen
        AllPositions = AllPositions.OrderBy(Pos => rnd.Next()).ToList();

        // Zuweisen der gemischten Positionen an die Karten
        for (int i = 0; i < AllCards.Length; i++)
        {
            AllCards[i].transform.position = AllPositions[i];
        }
    }

}
