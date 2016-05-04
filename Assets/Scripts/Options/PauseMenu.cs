using UnityEngine;
using System.Collections;

public class PauseMenu : AbstractBehavior {

	public GameObject myPauseMenu;
	public GameObject deathMenu;

	public bool paused = false;

	void OnEnable(){
		myPauseMenu = GameObject.Find ("PauseMenu");
		myPauseMenu.SetActive (false);
		deathMenu = GameObject.Find ("DeathMenu");

	}

	void Update(){

		var pauseButton = inputState.GetButtonValue (inputButtons [0]);
		if (pauseButton) {
//						Debug.Log(inputState.GetButtonHoldTime(inputButtons[0]) <.01f);
			if(inputState.GetButtonHoldTime(inputButtons[0]) <.01f){//keeps flickering to a minimum
				if (deathMenu.activeSelf) {
					paused = !paused;
					if (paused) {
						Debug.Log ("Paused.");
						Pause ();
					} else {
						Debug.Log ("Resume.");
						Resume ();
					}

				} else {
					//Do nothing
				}
			}
		}
		//		Debug.Log(inputState.GetButtonValue(inputButtons[0]));
		//		Debug.Log(inputButtons[0]);
	}

	public void Pause(){
		myPauseMenu.SetActive (true);
		Time.timeScale = 0; //sets time to 0, so nothing happens.
	}


	public void Resume(){
//		Debug.Log ("Resume()");
		Time.timeScale = 1;//if this is set to 0.3, it can create a slow motion effect.
		myPauseMenu.SetActive (false);
		paused = false;

	}

	public void Restart(){
//		Debug.Log ("Restart()");
		paused = false;
		Application.LoadLevel (Application.loadedLevel);//reload's the current level
		Resume();
	}

	public void MainMenu(){
		paused = false;
		//		StartCoroutine(GameObject.Find("GM").GetComponent<Transitions>().FadeStartLevel(1));//0 should correspond to Main Menu Scene as designated on Build Settings
		Application.LoadLevel (1);
		Resume ();
	}

	public void Quit(){

		Application.Quit ();
	}

}
