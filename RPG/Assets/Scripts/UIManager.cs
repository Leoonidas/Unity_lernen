using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject windowText;

    public void EnableTextWindow()
    {
        windowText.SetActive(true);
    }

    public void DisableTextWindow()
    {
        windowText.SetActive(false);
    }
}
