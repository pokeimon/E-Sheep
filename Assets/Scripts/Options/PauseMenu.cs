using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	public GameObject PauseUI;
	
	private bool paused = false;
	
	void Start(){
		
		PauseUI.SetActive (false);
		
	}
	
	void Update(){
		
		if (Input.GetButtonDown ("Pause")) {
			paused = !paused;
			if(GameObject.Find ("Player").GetComponent<Health>().currentHP == 0){
				paused = false;
			}
		}
		
		if (paused) {
			PauseUI.SetActive (true);
			Time.timeScale = 0; //sets time to 0, so nothing happens.
		}
		
		if (!paused) {
			PauseUI.SetActive (false);
			Time.timeScale = 1;//if this is set to 0.3, it can create a slow motion effect.
			
		}
		
	}

	public void Resume(){
		paused = false;
	}

	public void Restart(){
		paused = false;
		Application.LoadLevel (Application.loadedLevel);//reload's the current level
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
