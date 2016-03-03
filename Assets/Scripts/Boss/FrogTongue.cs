using UnityEngine;
using System.Collections;

public class FrogTongue : MonoBehaviour {

	public GameObject platform;
	public GameObject Boss;
	public float moveSpeed;
	public int startPoint=1;
	public Transform[] points;

	//creates an array of points that the platform will cycle through

	private Transform currentPoint;		//current point the platform will head too
	private int pointSelection;	
	private RangeAngle rangeScript;

	public bool autostart;

	void Start(){
		rangeScript = GetComponentInChildren<RangeAngle>();
		currentPoint = points[startPoint];
		pointSelection = startPoint;
		autostart = false;
		//FireTongue ();
	}

	void FixedUpdate(){

		//Boss.transform.Rotate(Vector3.zero,rangeScript.shotAngle,Space.Self);
		autostart = rangeScript.fire;

		if (autostart == true) {
			platform.transform.position = Vector3.MoveTowards 
				(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);

			if (platform.transform.position == currentPoint.position) {
				if (pointSelection == 0) {
					pointSelection = 1;
					rangeScript.fire = false;
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


