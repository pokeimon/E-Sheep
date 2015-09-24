using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	//This will be used to load the next level
	//If you look at the door insepction settings, this variable can have a set int
	//In the Unity editor, under File->Build Settings, each scene has a number
	//this allows for us to use this LevelLoad to call other scenes
	public int LevelLoad;

	
	void OnTriggerStay2D(Collider2D p){
		if(p.CompareTag("Player")){//Look for player tag
			if(Input.GetKeyDown("w") || Input.GetKeyDown("up")){
				StartCoroutine(FadeStartLevel());
				//Application.LoadLevel(LevelLoad);//if 'w' or 'up' keys are pressed it loads next level

			}
		}
	}

	IEnumerator FadeStartLevel(){
		float fadeTime = GameObject.Find("GM").GetComponent<Transitions>().FadeOut();
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(LevelLoad);
	}



}
