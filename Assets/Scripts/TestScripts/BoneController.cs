using UnityEngine;
using System.Collections;

public class BoneController : MonoBehaviour {
	public float speed;
	public int damage;
	public PlayerManager player;
	private Health health;
	public GameObject impactEffect;
	public float rotationSpeed;
	private Rigidbody2D myRigidbody2D;

	// Use this for initialization
	void Start () {
		player= FindObjectOfType<PlayerManager> ();
		health = GetComponent<Health> ();
		myRigidbody2D = GetComponent<Rigidbody2D> ();
		if (player.transform.position.x < transform.position.x) {
			speed = -speed;
			rotationSpeed = -rotationSpeed;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		myRigidbody2D.velocity = new Vector2 (speed, myRigidbody2D.velocity.y);
		myRigidbody2D.angularVelocity = rotationSpeed;
		//GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
		health.currentHP -= damage;
				
		}

		Instantiate (impactEffect, transform.position, transform.rotation);
			Destroy (gameObject);
	}
}
