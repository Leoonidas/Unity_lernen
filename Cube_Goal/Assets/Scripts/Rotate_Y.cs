using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Y : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(0, 15 * Time.deltaTime, 0) );
    }
}
