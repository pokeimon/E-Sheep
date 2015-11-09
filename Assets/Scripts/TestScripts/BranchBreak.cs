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

        }
    }
    
    //When the object's rigidbody exits the trigger collider, disable it (otherwise it'll get in the player's way)
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Breakable Branch")
        {
            other.gameObject.SetActive(false);
            other.GetComponentInParent<BoxCollider2D>().enabled = false;
        }

    }
}

