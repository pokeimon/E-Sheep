using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Wisp script. Method to find and attach itself to an enemy and populate Player's rangeList.
/// </summary>
public class WispScript : MonoBehaviour {

	List<GameObject> rangeList;
	GameObject target;
	GameObject player;

	public float lifeDuration;

	// Use this for initialization
	void OnEnable () {
		player = GameObject.Find ("Player");
		rangeList = player.GetComponent<ScannerScript> ().rangeList;
		//reset origination to player
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
		Debug.Log ("Wisp woke up.");
		lifeDuration = .02f;//will be replaced later if an enemy is found
		StartCoroutine (WaitForScan ());
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime*35f);

		}


	}

	/// <summary>
	/// Waits for scan. Initially, lifeDuration is only .6f seconds. 
	/// Within .5f seconds, if the OnTriggerEnter2D does not change the lifeDuration to 10f
	/// Then the Wisp is disabled
	/// </summary>
	/// <returns>The for scan.</returns>
	IEnumerator WaitForScan(){
		yield return new WaitForSeconds (.01f);
		StartCoroutine (SetLifeDuration (lifeDuration));
	}

	void OnTriggerEnter2D(Collider2D other){
		if (target == null) {
			if (other.CompareTag ("Enemy")) {
				Debug.Log ("Enemy Found");
				if (!rangeList.Contains (other.gameObject)) {
					lifeDuration = 10f;
//					Debug.Log ("Not in rangeList yet.");
					target = other.gameObject;//sets target
//				transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime);
					rangeList.Add (target);
				}

			}
		}
	}

	IEnumerator SetLifeDuration(float lifeDuration){
		yield return new WaitForSeconds (lifeDuration);
		this.gameObject.SetActive(false);
	}

	void OnDisable(){
		try{
			rangeList.RemoveAt (rangeList.IndexOf(target));//find the target in the rangelist and remove it
			target=null;//resets this wisps target
		}catch(Exception e){//if monster has died
			//do nothing
		}
	}
}
