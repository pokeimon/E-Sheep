using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTrackerScript : MonoBehaviour {

//	GameObject scoreObj;
	Text scoreVal;
	int score;

	// Use this for initialization
	void Awake () {
		scoreVal = GetComponent<Text> ();
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		scoreVal.text = "" + score;
	}

	public void IncreaseScoreBy(int val){
		score = score + val;
	}
}
