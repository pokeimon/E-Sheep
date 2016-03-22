using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Teleport script. Attach to GameObject with children transform as exit
/// </summary>
public class TeleportScript : MonoBehaviour {

	Transform exit;

	// Use this for initialization
	void Awake () {
		exit = gameObject.GetComponentsInChildren<Transform> ()[1];
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			other.transform.position = new Vector3 (
				exit.transform.position.x,
				exit.transform.position.y,
				other.transform.position.z);		
		}	
	}
}
