using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{

    public NavMeshAgent agent;



    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(mousePos, out hit))
            {


                agent.SetDestination(hit.point);
            }
            
        }
        
    }

}
