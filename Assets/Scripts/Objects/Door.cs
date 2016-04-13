using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	//This will be used to load the next level
	//If you look at the door insepction settings, this variable can have a set int
	//In the Unity editor, under File->Build Settings, each scene has a number
	//this allows for us to use this LevelLoad to call other scenes
	public int LevelLoad;

	public bool IsEndofLevel = false;
	public int level; //0,1,2
	
	void OnTriggerStay2D(Collider2D p){
		if(p.CompareTag("Player")){//Look for player tag
			if(Input.GetKeyDown("w") || Input.GetKeyDown("up")){
				if (IsEndofLevel) {
					//uncomment when set up
					//int score = GameObject.Find ("ScoreVal").GetComponent<ScoreTrackerScript> ().score;
					PlayerPrefs.SetInt("Level" + PlayerPrefs.GetInt("SelectedPlayer"), level+1);
					//uncomment when set up
					//GameObject.Find ("GM").GetComponent<PlayerSave> ().UpdateSave (level);

				}
				StartCoroutine(GameObject.Find("GM").GetComponent<Transitions>().FadeStartLevel(LevelLoad));
				//Application.LoadLevel(LevelLoad);//if 'w' or 'up' keys are pressed it loads next level

			}
		}
	}




}
