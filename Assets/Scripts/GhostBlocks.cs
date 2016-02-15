using UnityEngine;
using System.Collections;

public class GhostBlocks : MonoBehaviour {

	public float fadeTime = 3.0f;
	public float respawnTime = 4.0f;
	private bool onBlock = false;

	void Start () {
		
	}

	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			fadeOut ();	
		}
	}

	IEnumerator fadeOut () {
		yield return new WaitForSeconds (fadeTime);
		this.tag = "None";
	}

}
