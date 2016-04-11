using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	private GameObject sword;
	private GameObject player;
	private Health health;
	public int damage = 1;
	public float length = 4;
	public float swingSpeed = 10;

	void Awake() {
		
		if(this.transform.parent.tag == "Player"){
			sword = GameObject.FindGameObjectWithTag ("PlayerSword");
			player = GameObject.FindGameObjectWithTag ("Player");
			health = player.GetComponent<Health> ();
		}
		else {
			sword = GameObject.FindGameObjectWithTag ("EnemySword");
		}
	}
	
	void OnEnable() {
		if (this.transform.parent.tag == "Player") {
			if (health.currentHP == 1) {
				damage = 5;
				length = 2f;
			} else if (health.currentHP == 2) {
				damage = 10;
				length = 2f;
			} else if (health.currentHP == 3) {
				damage = 15;
				length = 2f;
			} else { //currentHP = 4
				damage = 15;
				length = 4f; //double length at 4 hp
			}
		}
		sword.transform.localPosition = new Vector3 (0f, 1.2f, 0f); //put sword and rotator in swing start position
		sword.transform.localScale = new Vector3 (0.2f, length, 1f);
		sword.transform.localEulerAngles = new Vector3 (0f, 0f, 0f);
		transform.localPosition = new Vector3 (0.75f, 0.25f, 0f);
		transform.localScale = new Vector3 (1f, length / 2f, 1f);
		transform.localEulerAngles = new Vector3 (0f, 0f, 30f);
	}

	void FixedUpdate () { 
		if (!((transform.localEulerAngles.z < 221) && (transform.localEulerAngles.z > 31))) {
			transform.Rotate (0, 0, -1f * swingSpeed); //swing sword untill it reaches end of swing
		} 
		else {
			gameObject.SetActive(false);
		}
	}
}
