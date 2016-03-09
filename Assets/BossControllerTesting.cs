using UnityEngine;
using System.Collections;



//NOTE: I had to change the Mallow FixedUpdate() to Update() for it to work

public class BossControllerTesting : MonoBehaviour {

	public GameObject someEnemy;

	public GameObject bossTongue;

	GameObject actualSummon1;
	GameObject actualSummon2;
	GameObject actualSummon3;
	GameObject bossSummon;


	public Transform summonBoss;
	public Transform summonArea;

	public Collider2D theBox;

	public Transform playerPosition;

	public bool playerEnter;

	int wave;

	//Testing purposes (Mein kampf)
	int e1Health;
	int e2Health;
	int e3Health;

	bool e1Active; 
	bool e2Active;
	bool e3Active;

	void Start(){
		//arbitrary Val
		e1Health = -3;
		e2Health = -3;
		e3Health = -3;
		//check if enemy is active
		e1Active = false;
		e2Active = false;
		e3Active = false;

		//what enemy to spawn
		wave = 0;

		//tells us if player enters
		playerEnter = false;

		//Once player enters arena, spawn first enemy, delete collider.
		theBox = gameObject.GetComponent<Collider2D>();

	}

	void Update(){

		//Debug.Log ("current wave: " + wave);
		if (e1Active) {
			e1Health = actualSummon1.GetComponent<Health> ().currentHP;
		} else if (e2Active) {
			e2Health = actualSummon2.GetComponent<Health> ().currentHP;
		} else if (e3Active) {
			e3Health = actualSummon3.GetComponent<Health> ().currentHP;
		}

		//if (actualSummon1.GetComponent<Health> ().currentHP == 0) {
		if(e1Health == 0){
			//Debug.Log ("e1 is dead " + wave);
			wave++;
			theBox.enabled = true;
		}
		//else if (actualSummon2.GetComponent<Health> ().currentHP == 0) {
		else if(e2Health == 0){
			//Debug.Log ("e2 is dead " + wave);
			wave++;
			theBox.enabled = true;
		}
		//else if (actualSummon3.GetComponent<Health> ().currentHP == 0) {
		else if(e3Health == 0){
			Debug.Log ("e3 is dead " + wave);
			wave++;
			theBox.enabled = true;
		}

	}
		
	void FixedUpdate(){
		if (playerEnter) {
			Debug.Log ("Wave: " + wave);
			BossEnemies (wave); 
		}
	}
		

	void BossEnemies(int n){

		if (n == 1 || n == 4 || n == 7) {
			actualSummon1 = (GameObject)Instantiate (someEnemy, summonArea.position, summonArea.rotation);
			//---------------
			e1Health = actualSummon1.GetComponent<Health> ().currentHP;
			e1Active = true;
			//---------------
			actualSummon1.GetComponent<Mallow> ().target = playerPosition;
			actualSummon1.GetComponent<SpriteRenderer> ().color = Color.green;
			playerEnter = false;
		}		
		else if (n == 2 || n == 5 || n == 8) {
			actualSummon2 = (GameObject)Instantiate (someEnemy, summonArea.position, summonArea.rotation);
			//---------------
			e2Health = actualSummon2.GetComponent<Health> ().currentHP;
			e2Active = true;
			//---------------
			actualSummon2.GetComponent<Mallow> ().target = playerPosition;
			actualSummon2.GetComponent<SpriteRenderer> ().color = Color.magenta;
			playerEnter = false;
		}	
		else if (n == 3 || n == 6 || n == 9) {
			actualSummon3 = (GameObject)Instantiate (someEnemy, summonArea.position, summonArea.rotation);
			//---------------
			e3Health = actualSummon3.GetComponent<Health> ().currentHP;
			e3Active = true;
			//---------------
			actualSummon3.GetComponent<Mallow> ().target = playerPosition;
			actualSummon3.GetComponent<SpriteRenderer> ().color = Color.red;
			playerEnter = false;
		}	
		/*
		else if (n == 4) {
			
			bossSummon.SetActive (true);
			bossSummon.transform.position = summonBoss.position;
			playerEnter = false;
		}
		*/

	}


	void OnTriggerEnter2D(Collider2D other)
	{


		//Debug.Log("Player Entered");
		if (other.name == "Player" && wave == 0)
		{
			Debug.Log ("player enter.");
			playerPosition = other.transform;

			playerEnter = true;
			wave += 1;//wave == 1

			theBox.enabled = false;
		}
		//else if(actualSummon1.GetComponent<Health> ().currentHP == 0 && other.name == "Player" ){
		else if(e1Health == 0 && other.name == "Player"){
			//actualSummon1.GetComponent<Health> ().currentHP = -1;
			e1Health = -1;
			e1Active = false;

			theBox.enabled = false;

			playerEnter = true;



		}
		//else if(actualSummon2.GetComponent<Health> ().currentHP == 0 && other.name == "Player" ){
		else if(e2Health == 0 && other.name == "Player"){
			//actualSummon2.GetComponent<Health> ().currentHP = -1;
			e2Health = -1;
			e2Active = false;

			theBox.enabled = false;
		
			playerEnter = true;

		}
		//else if(actualSummon3.GetComponent<Health> ().currentHP == 0 && other.name == "Player" ){
		else if(e3Health == 0 && other.name == "Player"){
			//actualSummon3.GetComponent<Health> ().currentHP = -1;

			e3Health = -1;
			e3Active = false;

			theBox.enabled = false;

			playerEnter = true;

			//temp to stop wave counter
			if(wave >= 10){
				playerEnter = false;
			}

		}

	}
}


