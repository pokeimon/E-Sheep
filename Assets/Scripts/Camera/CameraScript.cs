using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject focus;

	private Vector2 velocity;

	public float smoothTimeX;
	public float smoothTimeY;

	//Used to manipulate camera (use specific stage limits as defaults)
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	public float minZ;
	public float maxZ;

	public float cameraHalfWidth;
	public float cameraHalfHeight;



	//Debug purposes
	public bool debugCamera;
	public Camera cameraProperty;
	public Vector3 cameraNECorner;
	public Vector3 cameraSECorner;
	public Vector3 cameraSWCorner;
	public Vector3 cameraNWCorner;
	public GameObject markerNE;
	public GameObject markerSE;
	public GameObject markerSW;
	public GameObject markerNW;

	// Use this for initialization
	void Awake () {
		smoothTimeX = 0.5f;
		smoothTimeY = 0.4f;
		focus = GameObject.FindGameObjectWithTag ("Player");

		debugCamera = false;
		cameraProperty = GetComponent<Camera> ();

		cameraHalfWidth = cameraProperty.aspect * cameraProperty.orthographicSize;
		cameraHalfHeight = cameraProperty.orthographicSize;

		//enable markers
		markerNE = GameObject.Find("markerNE");
		markerSE = GameObject.Find ("markerSE");
		markerSW = GameObject.Find ("markerSW");
		markerNW = GameObject.Find ("markerNW");
	}
	
	// Update is called once per frame
	void Update () {
		DampenCameraShift (focus.transform.position.x, focus.transform.position.y);
		if (debugCamera) {
			DebugCameraCorners ();
		}
	}

	void DebugCameraCorners(){
		cameraNECorner = new Vector3 (
			transform.position.x + cameraHalfWidth,//gives us our x coordinate
			transform.position.y + cameraHalfHeight,//gives us our y coordinate
			1
		);

		cameraSECorner = new Vector3 (
			transform.position.x + cameraHalfWidth,//gives us our x coordinate
			transform.position.y - cameraHalfHeight,//gives us our y coordinate
			1
		);

		cameraSWCorner = new Vector3 (
			transform.position.x - cameraHalfWidth,//gives us our x coordinate
			transform.position.y - cameraHalfHeight,//gives us our y coordinate
			1
		);

		cameraNWCorner = new Vector3 (
			transform.position.x - cameraHalfWidth,//gives us our x coordinate
			transform.position.y + cameraHalfHeight,//gives us our y coordinate
			1
		);

		markerNE.transform.position = cameraNECorner;
		markerSE.transform.position = cameraSECorner;
		markerSW.transform.position = cameraSWCorner;
		markerNW.transform.position = cameraNWCorner;
	}

	void DampenCameraShift(float targetX, float targetY)
	{
		float posX = Mathf.SmoothDamp(transform.position.x, targetX, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp(transform.position.y, targetY, ref velocity.y, smoothTimeY);

//		transform.position = new Vector3(posX, posY, transform.position.z);

		transform.position = new Vector3 (
			(Mathf.Clamp (posX, minX, maxX)),
			(Mathf.Clamp (posY, minY, maxY)),
			(transform.position.z)
		);

	}

	public void SetClamps(Transform newArea){

//		minX = (newArea.position.x - newArea.localScale.x)/2;
//		maxX = (newArea.position.x + newArea.localScale.x)/2;

		//We can also use a smoothdamp here to help with transition.

		minX = newArea.position.x - newArea.localScale.x / 2 + cameraHalfWidth;
		maxX = newArea.position.x + newArea.localScale.x / 2 - cameraHalfWidth;

		if (minX > maxX) {
			minX = newArea.position.x;
			maxX = newArea.position.x;
		}


//
//		minY = newArea.position.y - newArea.localScale.y / 100f;
//		maxY = newArea.position.y + newArea.localScale.y / 100f;

//		minX = newArea.position.x;
//		maxX = newArea.position.x;

//		minY = (newArea.position.y - newArea.localScale.y) + cameraProperty.orthographicSize;
//		maxY = (newArea.position.y + newArea.localScale.y) - cameraProperty.orthographicSize;

		minY = newArea.position.y - newArea.localScale.y/2 + cameraHalfHeight;
		maxY = newArea.position.y + newArea.localScale.y/2 - cameraHalfHeight;

		if (minY > maxY) {
			minY = newArea.position.y;
			maxY = newArea.position.y;
		}

//		minZ = newArea.position.z - newArea.localScale.z / 2f;
//		maxZ = newArea.position.z + newArea.localScale.z / 2f;

	}


}
