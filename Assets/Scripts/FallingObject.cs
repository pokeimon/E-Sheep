using UnityEngine;
using System.Collections;

public class FallingObject : MonoBehaviour {
	public float despawnTime = 2.0f;
	public bool despawnOnTimer = true;
	public bool despawnOnImpact = false;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Rigidbody2D> ().isKinematic == false) {
			if (despawnOnTimer) {
				Destroy (this.gameObject, despawnTime); 
			}
		}
	}

	void  OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			this.GetComponent<Rigidbody2D> ().isKinematic = false;
		}
	}

	void OnCollisionEnter2D(Collision2D target) { 
		if (despawnOnImpact) {
			if ((target.gameObject.layer == 8) || (target.gameObject.layer == 9)) { //layer 8 is solid | layer 9 is player
				Destroy (this.gameObject,.2f); 
			}
		}
	}
}
