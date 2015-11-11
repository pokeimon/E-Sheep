using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	public Transform warpTarget;
	public Camera theCamera;
	public Vector3 playerPosition;

	IEnumerator OnTriggerEnter2D (Collider2D other) {

		ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> (); //find game object with fader tag

		yield return StartCoroutine (sf.FadeToBlack ());

		if (other.name == "Player") {
			other.gameObject.transform.position = warpTarget.position; //changes position of player
			//Camera.main.transform.position = warpTarget.position; //changes position of camera //might not need this line
			playerPosition = other.gameObject.transform.position;
			playerPosition.z = -2;
			theCamera.transform.position = playerPosition;
		}

		yield return StartCoroutine (sf.FadeToClear ());
	}
}
