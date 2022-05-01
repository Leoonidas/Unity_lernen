using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    public int Identifier;

    public float TargetHight = 0.01f;
    public int TargetRoation = -90;


    public void OnMouseDown()
    {
        // 
        Debug.Log("Clicked");
        FindObjectOfType<GameManager>().CardClicked(this);
    }

    private void Update()
    {
        // Bewegung der Karte nach oben oder unten, als die TargetHeight vom GameManager geändert wird
        float HeightValue = Mathf.MoveTowards(transform.position.y, TargetHight, 1 * Time.deltaTime);
        transform.position = new Vector3 (transform.position.x, HeightValue, transform.position.z);

        // smoothe Rotation über lerb(), wenn die Targetrotation vom GameManager geändert wird
        Quaternion RotationValue = Quaternion.Euler(TargetRoation, 0, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, RotationValue, 8 * Time.deltaTime);
    }

}
