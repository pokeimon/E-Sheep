using UnityEngine;
using System.Collections;

public class PlayerSword : MonoBehaviour {

	private GameObject sword;
	private GameObject player;
	public int damage = 5;
	public float length = 2;
	public float swingSpeed = 10;

	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player");
		sword = GameObject.FindGameObjectWithTag ("Sword");
	}
	
	void OnEnable() {
		//damage = player.health.currentHP * 5; //scale damage to HP
		//length = player.health.currentHP; // //scale sword length to HP
		sword.transform.localPosition = new Vector3 (0f, 1.2f, 0f); //put sword and rotator in swing start position
		sword.transform.localScale = new Vector3 (0.2f, length, 1f);
		sword.transform.localEulerAngles = new Vector3 (0f, 0f, 0f);
		transform.localPosition = new Vector3 (0.75f, 0.25f, 0f);
		transform.localScale = new Vector3 (1f, length / 2f, 1f);
		transform.localEulerAngles = new Vector3 (0f, 0f, 30f);
	}

	void FixedUpdate () { 
		if (!((transform.localEulerAngles.z < 221) && (transform.localEulerAngles.z > 31))) {
			transform.Rotate (0, 0, -1f * swingSpeed);
		} 
		else {
			gameObject.SetActive(false);
		}
	}
}
