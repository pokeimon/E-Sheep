using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Scanner script. Connect to scanner child of player
/// </summary>
public class ScannerScript : MonoBehaviour {

	float scannerRadius;
	public List<GameObject> rangeList;

	// Use this for initialization
	void Awake () {
		scannerRadius = 10.0f;
		rangeList = new List<GameObject> ();
		transform.localScale = new Vector3 (scannerRadius, scannerRadius, transform.localScale.z);
	}
	
//	// Update is called once per frame
//	void Update () {
//	
//	}

	/// <summary>
	/// When enemy enters trigger, place into rangeList;
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Enemy")) {
			rangeList.Add (other.gameObject);
		}
	}

	/// <summary>
	/// When enemy leaves trigger, remove from rangelist;
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag ("Enemy")) {
			for (int i = rangeList.Count - 1; i >= 0; i--) {//if done forwards, causes errors
				if (rangeList [i].Equals (other.gameObject)) {
					rangeList.RemoveAt (i);
				}
			}
		}
	}


}
