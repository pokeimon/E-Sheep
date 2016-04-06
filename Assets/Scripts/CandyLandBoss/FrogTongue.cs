using UnityEngine;
using System.Collections;

public class FrogTongue : MonoBehaviour {

	public GameObject platform;
	public float moveSpeed;
	public int startPoint;
	public Transform[] points; //creates an array of points that the platform will cycle through
	public bool hit = false;

	private Transform currentPoint;		//current point the platform will head too
	private int pointSelection;	


	private RangeAngle rangeScript;
	private BossController bossController;

	public bool autostart;

	void Start(){
		bossController = GameObject.Find("Boss controller").GetComponent<BossController>();
		rangeScript = GetComponentInChildren<RangeAngle>();

		currentPoint = points[startPoint];
		pointSelection = startPoint;
		autostart = false;
	}

	void FixedUpdate(){
		if (autostart == false) {
			//rangeScript.tongue.eulerAngles = new Vector3 (0, 0, rangeScript.shotAngle + 90);
		}

		if(bossController.fire && rangeScript.fire){
			autostart = true;
		}

		if (autostart == true) {
			platform.transform.position = Vector3.MoveTowards (platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed); // Tongue moves to next point
			if (platform.transform.position == currentPoint.position) { // If tongue reaches a point...
				if (pointSelection == 0) { // ... if that point is the oragin
					pointSelection = 1;
					autostart = false; // stop the tongue
					bossController.fire = false;
					Debug.Log ("Set fire false.");
					rangeScript.fire = false;
				}else if (pointSelection == 1) {				
					pointSelection = 0;
				}
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


