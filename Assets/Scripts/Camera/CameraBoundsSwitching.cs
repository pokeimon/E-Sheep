using UnityEngine;
using System.Collections;

public class CameraBoundsSwitching : MonoBehaviour {

	CameraSeek camera;

	public float cameraX;
	public float cameraY;

	void Start(){
		camera = GameObject.FindObjectOfType<CameraSeek> ();
	
	}

	//when a collider enters the bounds of the object this script is attached to
	void OnTriggerEnter2D (Collider2D other){
		cameraX = gameObject.transform.position.x;
		cameraY = gameObject.transform.position.y;
		
		//if that collider belongs to the player
		if (other.gameObject.name == "Player") {
			//change CameraFollow's bounds to corresponding this objects bounds
			//			Debug.Log ("Player entered " + gameObject.name);
			
			camera.SwitchStageCamera(
				gameObject.transform.position.y
				);
			
		}
		
	}
	void OnTriggerStay2D (Collider2D other){
		cameraX = gameObject.transform.position.x;
		cameraY = gameObject.transform.position.y;

		//if that collider belongs to the player
		if (other.gameObject.name == "Player") {
			//change CameraFollow's bounds to corresponding this objects bounds
//			Debug.Log ("Player entered " + gameObject.name);

			camera.SwitchStageCamera(
			                      gameObject.transform.position.y
			                      );

		}

	}
}
