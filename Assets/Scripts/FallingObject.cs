using UnityEngine;
using System.Collections;

public class FallingObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void  OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			GameObject.FindWithTag ("Ceilling").GetComponent<Rigidbody2D> ().isKinematic = false;
		}
	}
}
