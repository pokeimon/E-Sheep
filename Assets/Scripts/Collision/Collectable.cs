using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	public int energy = 1;
	public GameObject player;

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Player") {
			OnCollect(target.gameObject);
			OnDestroy();
		}
	}

	void OnCollect(GameObject target){
			Health health = target.GetComponent<Health>();
			health.EnergyPickUp(energy);
	}

	void OnDestroy(){
		Destroy (gameObject);
	}
	
}
