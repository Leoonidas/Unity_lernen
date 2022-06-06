using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{

    public NavMeshAgent agent;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Update()
    {
        // Linksklick
        if (Input.GetMouseButtonDown(0))
        {

            Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Falls ein gebaketes Objekte angeklickt wird
            if (Physics.Raycast(mousePos, out hit))
            {
                // Bewegung
                agent.SetDestination(hit.point);
            }
        }

        // falls der velocity Vektor größers als 0 ist, läuft der Charater
        bool isRunning = agent.velocity.magnitude > 0;
        anim.SetBool("isRunning", isRunning);
    }



    // Dialoge triggern
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            FindObjectOfType<UIManager>().EnableTextWindow();
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            FindObjectOfType<UIManager>().DisableTextWindow();
        }

    }
}

