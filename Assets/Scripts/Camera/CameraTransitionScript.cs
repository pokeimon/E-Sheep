using UnityEngine;
using System.Collections;

public class CameraTransitionScript : MonoBehaviour {

	public GameObject mainCamera;
	public CameraScript mainCameraScript;

	// Use this for initialization
	void Awake () {
		mainCamera = GameObject.Find ("Main Camera");
		mainCameraScript = mainCamera.GetComponent<CameraScript> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			mainCameraScript.SetClamps (transform);//sets the camera limits to this gameobject's transform.
		}
	}
	
	void OnTriggerStay2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			mainCameraScript.SetClamps (transform);//sets the camera limits to this gameobject's transform.
		}
	}
}
