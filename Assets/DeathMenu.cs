using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DeathMenu : MonoBehaviour {
	
	private Canvas deathMenu;
	public Button replay;
	public Button mainMenu;

	GameObject player;

	int health; 
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		deathMenu = this.gameObject.GetComponent<Canvas>();
		deathMenu.enabled = false;
		mainMenu = mainMenu.GetComponent<Button> ();
		replay = replay.GetComponent<Button> ();
	}

	void Update(){

		health = player.GetComponent<Health>().currentHP;

		if (health == 0) {
			deathMenu.enabled = true;
		} else
			deathMenu.enabled = false;
	}

	public void playerDeath(){
		deathMenu.enabled = true;
	}
	public void menuPress(){
		AudioListener.pause = false;
		Application.LoadLevel(1);
	}
	public void replayPress(){
		Application.LoadLevel(3);
	}

}
