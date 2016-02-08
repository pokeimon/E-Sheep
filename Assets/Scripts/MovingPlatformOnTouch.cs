using UnityEngine;
using System.Collections;

public class MovingPlatformOnTouch : MonoBehaviour {
	
	public GameObject platform;
	public float moveSpeed;				
	public int startPoint;
	public Transform[] points;			//creates an array of points that the platform will cycle through
	
	private Transform currentPoint;		//current point the platform will head too
	private int pointSelection;			

	public bool autostart;
	
	void Start(){
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
					pointSelection = 0;								//this starts the loop over again
				}
				currentPoint = points [pointSelection];
			}
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name.Equals ("Player")){
			Debug.Log ("Graham touched.");
			autostart = true;
		}
	}
}
