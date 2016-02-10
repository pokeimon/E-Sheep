using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	public GameObject myPauseMenu;
	public GameObject deathMenu;
	
	private bool paused = false;
	
	void Awake(){
		myPauseMenu = GameObject.Find ("PauseMenu");
		myPauseMenu.SetActive (false);
		deathMenu = GameObject.Find ("DeathMenu");
		
	}
	
	void Update(){
		
		if (Input.GetButtonDown ("Pause")) {
//			Debug.Log ("Pause menu activated.");
			if (deathMenu.activeSelf) {
				paused = !paused;
				if (paused) {
					Pause ();
				} else {
					Resume ();
				}

			} else {
				Pause ();
			}
		}		
	}

	public void Pause(){
		myPauseMenu.SetActive (true);
		Time.timeScale = 0; //sets time to 0, so nothing happens.
	}


	public void Resume(){
		myPauseMenu.SetActive (false);
		Time.timeScale = 1;//if this is set to 0.3, it can create a slow motion effect.
	}

	public void Restart(){
		paused = false;
//		Application.LoadLevel (Application.loadedLevel);//reload's the current level
		Resume();
	}

	public void MainMenu(){
		paused = false;
//		StartCoroutine(GameObject.Find("GM").GetComponent<Transitions>().FadeStartLevel(1));//0 should correspond to Main Menu Scene as designated on Build Settings
//		Application.LoadLevel (1);
		Resume ();
	}

	public void Quit(){

		Application.Quit ();
	}
	
}
