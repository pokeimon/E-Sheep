using UnityEngine;
using System.Collections;

public class JumpShockWave : MonoBehaviour {
	
	private Rigidbody2D body2d;
	public float waveSpeed = -20f;
	public float waveLifeTime = 5f;

	void Awake () {
		body2d = GetComponent<Rigidbody2D> ();
	}

	void OnEnable() {
		body2d.velocity = new Vector2 (waveSpeed, 0f);
		Invoke("Destroy", waveLifeTime); //destroy after set time if it doesn't collide
	}

	void OnCollisionEnter2D(Collision2D target) { 
		if (target.gameObject.layer == 8) { //solid layer
			Destroy();
		}
	}
		
	void Destroy() {
		gameObject.SetActive(false);
	}

	void OnDisable() {
		CancelInvoke();
	}
}
