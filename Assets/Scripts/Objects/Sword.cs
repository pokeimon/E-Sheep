using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	private Transform sword;
	private GameObject player;
	private Health health;
	public int damage = 1;
	public float length = 4;
	public float swingSpeed = 10;

	void Awake() {

		if(this.transform.parent.tag == "Player"){
			sword = transform.GetChild(0);
			player = GameObject.FindGameObjectWithTag ("Player");
			health = player.GetComponent<Health> ();
		}
		else {
			sword = transform.GetChild(0);;
		}
	}

	void OnEnable() {
		if (this.transform.parent.tag == "Player") {
			if (health.currentHP == 1) {
				damage = 5;
				length = 2f;
			} else if (health.currentHP == 2) {
				damage = 7;
				length = 2f;
			} else if (health.currentHP == 3) {
				damage = 9;
				length = 2f;
			} else { //currentHP = 4
				damage = 12;
				length = 2f; //double length at 4 hp
			}
		}

		//put sword and rotator in swing start position

		if (this.transform.parent.tag == "Player") {
			transform.localScale = new Vector3 (1f, length / 2f, 1f);
			transform.localPosition = new Vector3 (0.75f, 0.25f, 0f);
			sword.localPosition = new Vector3 (0f, 1.2f, 0f); 
			sword.localScale = new Vector3 (0.2f, length, 1f);
		} 
		else {// is boss
			transform.localScale = new Vector3 (1f, 1f, 1f);
			transform.localPosition = new Vector3 (0.15f, 0.05f, 0f);
			sword.localPosition = new Vector3 (0f, 0.46f, 0f); 
			sword.localScale = new Vector3 (0.025f, .90f, 1f);	

		}
		sword.transform.localEulerAngles = new Vector3 (0f, 0f, 0f);


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
