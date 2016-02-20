using UnityEngine;
using System.Collections;

public class FallingObject : MonoBehaviour {
	public float despawnTime = 5.0f;
	public bool despawn = true;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Rigidbody2D> ().isKinematic == false) {
			if (despawn) {
				Destroy (this.gameObject, despawnTime); 
			}
		}
	}

	void  OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			this.GetComponent<Rigidbody2D> ().isKinematic = false;
		}
	}
}
