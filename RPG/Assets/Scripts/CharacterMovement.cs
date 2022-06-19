using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{

    public NavMeshAgent agent;
    public Animator anim;
    public float damage = 20;


    public void Awake()
    {
        LoadGame();
    }

    private void Update()
    {
        // Linksklick
        if (Input.GetMouseButtonDown(0) && anim.GetBool("isAttacking") == false)
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


        // Rechtsklick(Angriff)
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("isAttacking", true);
        }


        // Speichern
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SaveGame();
        }
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


    public void Attack()
    {
        anim.SetBool("isAttacking", false);
        // array aller gameobjects mit health
        Health[] healthFound = FindObjectsOfType<Health>();
        // [0] -> Playyer
        // [1] -> Gegner

        foreach (Health health in healthFound)
        {
            if(health.gameObject.tag == "Enemy")
            {
                float distance = Vector3.Distance(transform.position, health.transform.position);

                if (distance < 1.5)
                {
                    float randomDamage = Random.Range(damage-5, damage+5);

                    health.maxHealth -= randomDamage;
                    health.ActivateAttacking();
                }                
            }
        }

    }


    public void SaveGame()
    {
        Vector3 posToSave = transform.position;

        PlayerPrefs.SetFloat("xPos", posToSave.x);
        PlayerPrefs.SetFloat("yPos", posToSave.y);
        PlayerPrefs.SetFloat("zPos", posToSave.z);
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("xPos"))
        {
            Vector3 loadedPos = new Vector3();

            loadedPos.x = PlayerPrefs.GetFloat("xPos");
            loadedPos.y = PlayerPrefs.GetFloat("yPos");
            loadedPos.z = PlayerPrefs.GetFloat("zPos");

            transform.position = loadedPos;
        }
    }
}

