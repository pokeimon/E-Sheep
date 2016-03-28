using UnityEngine;
using System.Collections;

public class BoneController : MonoBehaviour {
	public float bulletLifeTime = 7f;
	public float speed;
	public int damage;
	public PlayerManager player;
	private Health health;
	public GameObject impactEffect;
	public float rotationSpeed;
	private Rigidbody2D myRigidbody2D;
	private GameObject objPool;

	// Use this for initialization
	void Awake () {
		player= FindObjectOfType<PlayerManager> ();
		myRigidbody2D = GetComponent<Rigidbody2D> ();
		if (player.transform.position.x < transform.position.x) {
			speed = -speed;
			rotationSpeed = -rotationSpeed;
		}
		objPool = GameObject.Find("SkeletonBoneObjectPool");
		this.transform.SetParent(objPool.transform);
	
	}
	void OnEnable() {
		Invoke("Destroy", bulletLifeTime); //destroy after set time if it doesn't collide
	}
		
	void Update () {
		myRigidbody2D.velocity = new Vector2 (speed, myRigidbody2D.velocity.y);
		myRigidbody2D.angularVelocity = rotationSpeed;
		//GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y);
	}

	void OnCollisionEnter2D(Collision2D target) { 
		//Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy();
	}

	void Destroy() {
		gameObject.SetActive(false);
	}

	void OnDisable() {
		CancelInvoke();
	}
}
