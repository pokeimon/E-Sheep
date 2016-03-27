using UnityEngine;
using System.Collections;



//NOTE: I had to change the Mallow FixedUpdate() to Update() for it to work

public class BossControllerSteven : MonoBehaviour {

	public GameObject someEnemy;

	GameObject actualSummon1;
	GameObject actualSummon2;
	GameObject actualSummon3;

	//public Transform summonBoss;
	public Transform summonArea;

	public Collider2D theBox;

	public Transform playerPosition;

	public bool fire; //Added by Steven
	public bool playerEnter;

	int wave;

	void Start(){
		//what enemy to spawn
		wave = 0;

		//tells us if player enters
		playerEnter = false;

		//Once player enters arena, spawn first enemy, delete collider.
		theBox = gameObject.GetComponent<Collider2D>();
	}

	void Update(){
		if (wave > 0) {
			if (actualSummon1.GetComponent<Health> ().currentHP == 0) {
				wave++;
				theBox.enabled = true;
			} else if (actualSummon2.GetComponent<Health> ().currentHP == 0) {
				wave++;
				theBox.enabled = true;
			} else if (actualSummon3.GetComponent<Health> ().currentHP == 0) {
				wave++;
				theBox.enabled = true;
			}
		}
	}



	void FixedUpdate(){
		if (playerEnter) {
			BossEnemies (wave);
		}
	}

	void BossEnemies(int n){
		if (n == 1) {
			actualSummon1 = (GameObject)Instantiate (someEnemy, summonArea.position, summonArea.rotation);
			actualSummon1.GetComponent<Mallow> ().target = playerPosition;
			actualSummon1.GetComponent<SpriteRenderer> ().color = Color.green;
			playerEnter = false;
		}		
		else if (n == 2) {
			actualSummon2 = (GameObject)Instantiate (someEnemy, summonArea.position, summonArea.rotation);
			actualSummon2.GetComponent<Mallow> ().target = playerPosition;
			actualSummon2.GetComponent<SpriteRenderer> ().color = Color.magenta;
			playerEnter = false;
		}	
		else if (n == 3) {
			actualSummon3 = (GameObject)Instantiate (someEnemy, summonArea.position, summonArea.rotation);
			actualSummon3.GetComponent<Mallow> ().target = playerPosition;
			actualSummon3.GetComponent<SpriteRenderer> ().color = Color.red;
			playerEnter = false;
		}	
		else if (n == 4) {
			fire = true; // Added by Steven
			playerEnter = false;
		}
	}


	void OnTriggerEnter2D(Collider2D other){
		
		//Debug.Log("Player Entered");
		if (other.name == "Player" && wave == 0) {
			Debug.Log ("player enter.");
			playerPosition = other.transform;

			playerEnter = true;
			wave = 1;//wave == 1

			theBox.enabled = false;
		} else if (actualSummon1.GetComponent<Health> ().currentHP == 0 && other.name == "Player") {
			actualSummon1.GetComponent<Health> ().currentHP = -1;
			theBox.enabled = false;
			wave = 2;
			playerEnter = true;

		} else if (actualSummon2.GetComponent<Health> ().currentHP == 0 && other.name == "Player") {
			actualSummon2.GetComponent<Health> ().currentHP = -1;
			theBox.enabled = false;
			wave = 3;
			playerEnter = true;

		} else if (actualSummon3.GetComponent<Health> ().currentHP == 0 && other.name == "Player") {
			actualSummon3.GetComponent<Health> ().currentHP = -1;
			theBox.enabled = false;
			wave = 4;
			playerEnter = true;
		}
	}
}
