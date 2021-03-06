using UnityEngine;
using System.Collections;


//This script is for each radial collider that expands
//The ResetRadial() method disables the corresponding radial collider for a little bit then re-enables it.
//This allows the PathFinding script to use other directions.
public class RadialScript : MonoBehaviour {

	float resetTime;
	int layerToCollideWith;

	void Awake(){
		resetTime = .2f;
		layerToCollideWith = 8;//8 is our solid layer
	}

	void OnTriggerEnter2D (Collider2D other){
//		Debug.Log (other.gameObject.layer + " encountered.");
		if(other.gameObject.layer.Equals(layerToCollideWith)){
//			Debug.Log ("Wall is sensed.");
			StartCoroutine (ResetRadial());
		}
	}

	IEnumerator ResetRadial(){
		transform.GetComponent<Collider2D> ().enabled = false;
		yield return new WaitForSeconds (resetTime);
		transform.GetComponent<Collider2D> ().enabled = true;
	}
}
