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
	
}
