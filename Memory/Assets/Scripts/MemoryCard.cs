using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    public int Identifier;

    public void OnMouseDown()
    {
        // 
        Debug.Log("Clicked");
        FindObjectOfType<GameManager>().CardClicked(this);
        

    }

}
