using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasHealth : MonoBehaviour
{
    public Text textHealth;
    public Health health;


    public void Update()
    {
        // Darstellung der Aktuellen Leben
        textHealth.text = health.maxHealth.ToString("f0");

        // Ausrichtung zur Kamera
        transform.rotation = Camera.main.transform.rotation;
    }
}
