using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public AudioSource AudioSource;
    public float speed = 3.0f;
    Vector3 StartPos;
    public bool IsGrounded;

    // Start is called before the first frame update
    void Start()
    {
        // Speichern der Startposition
        StartPos = transform.position;
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




        // Springen
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded == true)
        {
            rb.AddForce(Vector3.up * 3, ForceMode.Impulse);
            IsGrounded = false;

            // Sound
            AudioSource.Play();
        }





        // Zurücksetzten beim Herunterfallen
        if (transform.position.y < -10)
        {
            transform.position = StartPos;
        }
    }


    // Methode zum Registrieren einer Kollision
    private void OnCollisionEnter(Collision collider)
    {
        Debug.Log("Player collision with " + collider.transform.name);

        // Sprung zurücksetzten
        IsGrounded = true;




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
