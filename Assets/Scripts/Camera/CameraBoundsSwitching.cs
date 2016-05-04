using UnityEngine;
using System.Collections;

public class CameraBoundsSwitching : MonoBehaviour {

	private CameraFollow camera;

	public float cameraX;
	public float cameraY;

	float boundsYLow;
	float boundsYHigh;
	float boundsYCenter;

	void Start(){
		camera = GameObject.FindObjectOfType<CameraFollow> ();
	
	}

	//when a collider enters the bounds of the object this script is attached to
//	void OnTriggerEnter2D (Collider2D other){
//		cameraX = gameObject.transform.position.x;
//		cameraY = gameObject.transform.position.y;
//		
//		//if that collider belongs to the player
//		if (other.gameObject.name == "Player") {
//			//change CameraFollow's bounds to corresponding this objects bounds
//			//			Debug.Log ("Player entered " + gameObject.name);
//			
//			camera.ChangeFloor(gameObject.transform.position.y);
//			
//		}
//		
//	}

	void OnTriggerEnter2D (Collider2D other){
		//need to account for camera size and camera zone size
		boundsYCenter = gameObject.transform.position.y;
		boundsYLow = boundsYCenter - (gameObject.transform.localScale.y / 5);
		boundsYHigh = boundsYCenter + (gameObject.transform.localScale.y / 5);

//		cameraX = gameObject.transform.position.x;
//		cameraY = gameObject.transform.position.y;

		//if that collider belongs to the player
		if (other.gameObject.name == "Player") {
			//change CameraFollow's bounds to corresponding this objects bounds
//			Debug.Log ("Player entered " + gameObject.name);

			camera.ChangeYBounds(boundsYLow, boundsYHigh);

		}

	}
}
