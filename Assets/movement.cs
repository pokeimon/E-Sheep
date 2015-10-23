using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	public GameObject platform;
	public float moveSpeed;
	public int startPoint;
	public Transform[] points;
	
	private Transform currentPoint;
	private int pointSelection;
	

	bool keyDown = false;

	void Start(){
		currentPoint = points[startPoint];
		pointSelection = startPoint;
	}
	
	void Update(){
		if(Input.GetKey(KeyCode.Keypad1)){
			keyDown = true;
		}
		if (keyDown) {
			StationMoveDown ();
		}

	}

	void StationMoveDown(){

		if(platform.transform.position == points[1].position){
			platform.transform.position = points[1].position;
			keyDown = false;
		}
		else{
			platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
			if(platform.transform.position == currentPoint.position){
				pointSelection++;
				if(pointSelection == points.Length){
					pointSelection = 0;
				}
				currentPoint = points[pointSelection];
			}
		}

	}
	void StationMoveUp(){
		
		if(platform.transform.position == points[0].position){
			platform.transform.position = points[0].position;
		}
		else{
			platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
			if(platform.transform.position == currentPoint.position){
				pointSelection++;
				if(pointSelection == points.Length){
					pointSelection = 0;
				}
				currentPoint = points[pointSelection];
			}
		}
		
	}
}
