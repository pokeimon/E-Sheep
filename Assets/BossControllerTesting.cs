using UnityEngine;
using System.Collections;

public class BossControllerTesting : MonoBehaviour {

	public GameObject someEnemy1;
	public GameObject someEnemy2;
	public GameObject someEnemy3;

	GameObject actualSummon;
	public Transform summonArea;

	public Collider2D player;

	public Transform playerPosition;
	public bool playerEnter;

	void Start(){
		playerEnter = false;

		//testing purposes
		someEnemy1.GetComponent<Health> ().currentHP = 2;
		someEnemy2.GetComponent<Health>().currentHP = 2;
		someEnemy3.GetComponent<Health>().currentHP = 2;


	}

	void Update(){
		if (playerEnter) {
			BossEnemies ();
		}
	}

	void BossEnemies(){
		
		actualSummon = (GameObject)Instantiate(someEnemy1, summonArea.position, summonArea.rotation);
		actualSummon.GetComponent<Mallow>().target = playerPosition;
		actualSummon.GetComponent<SpriteRenderer> ().color = Color.green;


//		if(someEnemy1.GetComponent<Health>().currentHP == 0){
//			actualSummon = (GameObject)Instantiate(someEnemy2, summonArea.position, summonArea.rotation);
//			actualSummon.GetComponent<Mallow>().target = playerPosition;
//			actualSummon.GetComponent<SpriteRenderer> ().color = Color.magenta;
//		}

	}


	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log("Player Entered");
		if (other.name == "Player")
		{
			Debug.Log ("player enter.");
			player = other;
			playerPosition = other.transform;
			playerEnter = true;
			Update ();//was having issues here, but calling Update fixed it.
			gameObject.SetActive (false);

		}
	}
}
