using UnityEngine;
using System.Collections;

public class HorrorLandBoss : MonoBehaviour {
	private ObjectPooler objectPooler;
	private Health health; //may not be needed
	private Rigidbody2D body2d;// may not be needed
	private GameObject sword;
	public Transform firingPoint;
	public float shootDelay = 2f;
	public float currentShootDelay = 2f;
	public float meleeDelay = 20f;
	public float currentMeleeDelay = 0f;
	public bool shoot = false;
	public bool melee = false;

	void Awake(){
		objectPooler = GameObject.Find("HorrorBossObjectPool").GetComponent<ObjectPooler>();
		health = GetComponent<Health> ();
		body2d = GetComponent<Rigidbody2D> ();
		sword = transform.GetChild(0).gameObject;
	}

	void FixedUpdate() {
		if (sword.activeSelf) {
			melee = true;
		}
		else {
			melee = false;
		}
		if (!melee && (currentShootDelay > shootDelay)) { //try shoot
			Shoot();
			currentShootDelay = 0f;
		}
		if(!melee && (currentMeleeDelay > meleeDelay)){ //try melee
			Melee();
			currentMeleeDelay = 0f;
		}
			
		currentShootDelay += Time.deltaTime;
		currentMeleeDelay += Time.deltaTime;
	
	}

	void Shoot(){
		GameObject obj = objectPooler.getPooledObject();

		if (obj != null) {			
			obj.transform.position = firingPoint.position;
			obj.transform.rotation = transform.rotation;
			obj.transform.localScale = transform.localScale * .2f;
			obj.SetActive (true);
		}
	}

	void Melee(){
		GameObject sword = transform.GetChild(0).gameObject;
		sword.SetActive(true); //swing sword and reset for delay
	}
}
