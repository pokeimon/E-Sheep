
/*
using UnityEngine;
using System.Collections;


This is supposed to trigger a boolean from the player scripts to enable the Up button to climb
Can't get it to work since I don't fully understand how our input is being handled
For now, just sets player gravity to zero (can jump up)

public class LadderZone : MonoBehaviour
{

    private Climb thePlayer;

    //accesses a simple climb script, will be changed later once I have a better grasp of input handling
    void Start()
    {
        thePlayer = FindObjectOfType<Climb>();
    }


    //On entering the trigger, switch player boolean .onLadder = true;
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "Player")
        {
            thePlayer.onLadder = true;
        }
    }


    //On exiting the trigger, switch player boolean .onLadder = false;
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            thePlayer.onLadder = false;
        }
    }
}

*/