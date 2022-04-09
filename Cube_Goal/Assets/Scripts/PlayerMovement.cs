using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float speed = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!" + transform.name);
    }

    // Update is called once per frame
    void Update()
    {
        // Imput.GetAxis wandelt WASD und Pfeiltsten Eingabe direkt in eine Änderung 1/Frame um
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Jump");
        float z = Input.GetAxis("Vertical");

        // Neue Position aus Eingabe, angepasster Geschwindigkeit und DeltaTime zum FPS Ausgleich
        rb.MovePosition(rb.position + speed * (new Vector3(x, y, z)) * Time.deltaTime);

    }


    // Methode zum Registrieren einer Kollision
    private void OnCollisionEnter(Collision collider)
    {
        Debug.Log("Player collision with " + collider.transform.name);

        // Erkennen einer Kollision mit "Ziel"
        if (collider.transform.tag == "Goal")
        {
            Destroy(collider.gameObject);

            // Bei Kollision mit Ziel wird neues Level aufgerufen
            GameManager manager = FindObjectOfType<GameManager>();
            manager.LoadNextLevel();

        }

        


    }


}
