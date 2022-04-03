using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float speed = 0.02f;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!" + transform.name);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Jump");
        float z = Input.GetAxis("Vertical");

        rb.MovePosition(rb.position + speed * (new Vector3(x, y, z)));

       

    }
}
