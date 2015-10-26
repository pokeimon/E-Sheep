using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	public Transform warpTarget;

	void OnTriggerEnter2D (Collider2D other) {

		if (other.name == "Player") {
			other.gameObject.transform.position = warpTarget.position; //changes position of player
			//Camera.main.transform.position = warpTarget.position; //changes position of camera //might not need this line

		}

	}

}
