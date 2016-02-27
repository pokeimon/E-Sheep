using UnityEngine;
using System.Collections;

public class TestingTongue : MonoBehaviour {

	public GameObject platform;
	public float moveSpeed;				
	public int startPoint;
	public Transform[] points;			//creates an array of points that the platform will cycle through

	private Transform currentPoint;		//current point the platform will head too
	private int pointSelection;			

	public bool autostart;

	public Transform startingPoint;

	void Start(){
		platform.transform.position = startingPoint.position;
		currentPoint = points[startPoint];
		pointSelection = startPoint;
		autostart = false;
	}

	void Update(){
		if (autostart == true) {
			platform.transform.position = Vector3.MoveTowards 
				(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);

			if (platform.transform.position == currentPoint.position) {
				pointSelection++;
				if (pointSelection == points.Length) {				//once at the last array it resets the pointSelection to 0
					autostart = false;								//this starts the loop over again
					Debug.Log ("autostart = f");
				}

				currentPoint = points [2];
				autostart = false;	
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player" ){
			Debug.Log ("Gate touched.");
			autostart = true;
			Debug.Log ("autostart = true");
		}

	}

}

