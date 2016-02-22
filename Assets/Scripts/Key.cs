using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	public GameObject PlatForms;
	public GameObject door;
	//public Renderer rend;


	// Use this for initialization
	void Start () {
		this.GetComponent<SpriteRenderer> ().enabled = true;
		//rend.enabled = true;
		door.GetComponent<Door> ().enabled = false;
		//Sets the Platforms as innactive
		PlatForms.SetActive(false);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			this.GetComponent<SpriteRenderer> ().enabled = false;
			//rend.enabled = false;
			door.GetComponent<Door> ().enabled = true;
			PlatForms.SetActive(true);
		}
	}
}
