using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	public Transform warpTarget;
	public Camera theCamera;
	public Vector3 playerPosition;

	IEnumerator OnTriggerEnter2D (Collider2D other) {


		if (other.name == "Player") {
			Collider2D coll = GameObject.Find("Player").GetComponent<Collider2D>();
			coll.attachedRigidbody.isKinematic = true;
			float fadeTime = GameObject.Find("GM").GetComponent<Transitions>().FadeOut();	//fades out when player exits
			yield return new WaitForSeconds (fadeTime);										//waits till fading out is finished
			other.gameObject.transform.position = warpTarget.position;						//changes position of player
			playerPosition = other.gameObject.transform.position;							//moves player position
			playerPosition.z = -2;												
			theCamera.transform.position = playerPosition;									//moves camera
			GameObject.Find("GM").GetComponent<Transitions>().FadeIn();						//fades in
			GameObject.Find ("Player").GetComponent<Jump>().warp = false;
			coll.attachedRigidbody.isKinematic = false;
		}
	}
}
