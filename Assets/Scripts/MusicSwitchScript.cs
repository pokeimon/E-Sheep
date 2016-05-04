using UnityEngine;
using System.Collections;

public class MusicSwitchScript : MonoBehaviour {

	AudioSource audio1;
	AudioSource audio2;

	// Use this for initialization
	void Awake () {
		audio1 = GameObject.Find ("Main Camera").GetComponent<AudioSource> ();
		audio2 = transform.GetComponent<AudioSource> ();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			audio1.Stop ();
			audio2.Play ();
		}
	}
}
