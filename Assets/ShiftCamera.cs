using UnityEngine;
using System.Collections;

/*
This script can be used for moving the camera around
For now it just uses invisible objects for the camera to point at (via CameraFollow's ChangeCameraFocus method)
Will make it more dynamic later
*/
public class ShiftCamera : MonoBehaviour {

    private CameraFollow myCameraScript;

    void Awake()
    {
        myCameraScript = GameObject.FindObjectOfType<CameraFollow>();
    }

    //On entering the trigger area, switch focus
    void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player") { 
            myCameraScript.ChangeCameraFocus("First Ditch", true);
        }
    }

    //On exiting the trigger area, switch the focus to another invisible gameObject (will refocus on default bounds later on)
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            myCameraScript.ChangeCameraFocus("Above First Ditch", true);
        }
    }

}
