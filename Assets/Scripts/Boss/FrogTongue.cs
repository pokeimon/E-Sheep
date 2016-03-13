using UnityEngine;
using System.Collections;

public class FrogTongue : MonoBehaviour {

	public GameObject platform;
	public float moveSpeed;
	public int startPoint;
	public Transform[] points;

	//creates an array of points that the platform will cycle through

	private Transform currentPoint;		//current point the platform will head too
	private int pointSelection;	
	private RangeAngle rangeScript;

	public bool autostart;
	public bool atOrigin = true;

	void Start(){
		rangeScript = GetComponentInChildren<RangeAngle>();
		currentPoint = points[startPoint];
		pointSelection = startPoint;
		autostart = false;
		//FireTongue ();
	}

	void FixedUpdate(){
		if (rangeScript.c.enabled == false) {
			rangeScript.tongue.eulerAngles = new Vector3 (0, 0, rangeScript.shotAngle + 90);
		}
			
		autostart = rangeScript.fire;

		if (autostart == true) {
			platform.transform.position = Vector3.MoveTowards (platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed); // Tongue moves to next point
			if (platform.transform.position == currentPoint.position) { // If tongue reaches a point...
				if (pointSelection == 0) { // ... if that point is the oragin
					pointSelection = 1;
					rangeScript.fire = false; // stop the tongue
				}else if (pointSelection == 1) {				
					pointSelection = 0;
				}
				Debug.Log ("PointSelection: " + pointSelection);
				currentPoint = points [pointSelection];
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Player" && col.gameObject.tag.Equals ("PlayerSword")){
			Debug.Log ("Set boss to damage state.");
		}
	}
}


