using UnityEngine;
using System.Collections;

public class ResetCamera : MonoBehaviour {

    private CameraFollow myCameraScript;

    void Awake() {
        myCameraScript = GameObject.FindObjectOfType<CameraFollow>();
    }

    //Used for transitioning to the default Camera View
    void OnTriggerExit2D(Collider2D other) {
        if (other.name == "Player") {
            myCameraScript.ResetCameraFocus();
        }
    }
}
