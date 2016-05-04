using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DeathMenu : MonoBehaviour {
	
	private Canvas deathMenu;
	public Button replay;
	public Button mainMenu;

	public GameObject respawnPoint;

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
		Application.LoadLevel(Application.loadedLevel);
	}
	public void continuePress(){
		Debug.Log ("player before load: " + player.transform.position.ToString ());

		Application.LoadLevel(Application.loadedLevel);
		Debug.Log ("player at load: " + player.transform.position.ToString ());

		Vector3 newRespawn = new Vector3(
			PlayerPrefs.GetFloat("RespawnX"),
			PlayerPrefs.GetFloat("RespawnY"),
			PlayerPrefs.GetFloat("RespawnZ")
		);
		Debug.Log ("respawn at: " + newRespawn.ToString ());

		player.transform.localPosition = newRespawn;//somehow this is not carrying over//is it getting rewritten by loadlevel?
		Debug.Log ("player at move: " + player.transform.position.ToString ());
		Debug.Log ("playerLocal at move: " + player.transform.localPosition.ToString ());

		//Plan:
		//On scene awake, check player prefs for isContinueFlagged
		//if null, don't do anything
		//if it is flagged as true, then pull RespawnX, RespawnY, RespawnZ, and move the player's position
		//let's put it all in camera

	}
}
