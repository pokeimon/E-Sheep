using UnityEngine;
using System.Collections;

public class BitCoinScript : MonoBehaviour {

	ScoreTrackerScript scoreScript;
	private AudioSource audio;
	private AudioSource[] audioList;
	int audioCount;
	public int currentAudio;


	// Use this for initialization
	void Awake () {
		scoreScript = GameObject.Find ("ScoreVal").GetComponent<ScoreTrackerScript> ();
		audioList = gameObject.transform.parent.GetComponents<AudioSource> ();
		audioCount = audioList.Length;
		currentAudio = 0;
//		audio = gameObject.transform.parent.GetComponent<AudioSource> ();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		bool notAllAudioUsed = true;
		if (other.gameObject.CompareTag ("Player")) {
			while (notAllAudioUsed) {
				if (audioList [currentAudio % audioCount].isPlaying) {
					currentAudio++;
				} else {
					audioList [currentAudio % audioCount].Play ();
					notAllAudioUsed = false;
				}
			}

			scoreScript.IncreaseScoreBy (100);
			gameObject.SetActive (false);
		}
	}

	void PlayCoinSound(){
		
	}
}
