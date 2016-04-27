using UnityEngine;
using System.Collections;

public class BitCoinHeavyScript : MonoBehaviour {

	ScoreTrackerScript scoreScript;
	private AudioSource audio;
	private AudioSource[] audioList;
	int audioCount;
	public int currentAudio;


	// Use this for initialization
	void Awake () {
		scoreScript = GameObject.Find ("ScoreVal").GetComponent<ScoreTrackerScript> ();
		audioList = gameObject.transform.parent.parent.GetComponents<AudioSource> ();
		audioCount = audioList.Length;
		currentAudio = 0;
		//		audio = gameObject.transform.parent.GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		bool notAllAudioUsed = true;
		if (other.gameObject.CompareTag ("Player")) {

			audioList [getAvailableAudio()].Play ();

			scoreScript.IncreaseScoreBy (100);
			gameObject.transform.parent.gameObject.SetActive (false);
		}
	}

	int getAvailableAudio(){
		for (int i = 0; i < audioList.Length; i++) {
			if (!(audioList [i].isPlaying)) {
				Debug.Log ("AudioSource: " + i);
				return i;
			}

		}
		//if all audiosources are playing, stop the first one and replay it.
		audioList [0].Stop ();
		Debug.Log ("AudioSource: " + 0);
		return 0;
	}
}
