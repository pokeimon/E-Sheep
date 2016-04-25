using UnityEngine;
using System.Collections;

/*
This script is attached to a gameobject (branch)
It simulates a branch snapping off.
*/
public class BranchBreak : MonoBehaviour
{
    private Rigidbody2D breakrigidbody2d;

    //When the player enters the trigger collider, drop this object's rigidbody
    void OnTriggerEnter2D(Collider2D other)
    {
//        Debug.Log("Trigger Entered");
        if (other.name == "Player")
        {
            breakrigidbody2d = GetComponentInChildren<Rigidbody2D>();
            //Debug.Log(breakrigidbody2d.name);
            breakrigidbody2d.isKinematic = false;
			gameObject.SetActive(false);

        }
    }
}

