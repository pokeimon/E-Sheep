using UnityEngine;
using System.Collections;

public class BitCoinScript : MonoBehaviour {

	ScoreTrackerScript scoreScript;
	public AudioSource audio;


	// Use this for initialization
	void Awake () {
		scoreScript = GameObject.Find ("ScoreVal").GetComponent<ScoreTrackerScript> ();
		audio = gameObject.transform.parent.GetComponent<AudioSource> ();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			audio.Play ();
			scoreScript.IncreaseScoreBy (100);
			gameObject.SetActive (false);
		}
	}
}
