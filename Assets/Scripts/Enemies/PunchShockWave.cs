using UnityEngine;
using System.Collections;

public class PunchShockWave : MonoBehaviour {

	private GameObject punchShockWave;
	private Rigidbody2D body2d;
	public float punchDelay = 2f;
	public float currentPunchDelay = 0f;
	public float waveSpeed = -15f;
	public float waveLifeTime = 0.8f;

	void Awake () {
		body2d = GetComponent<Rigidbody2D> ();
		punchShockWave = transform.GetChild(0).gameObject;
	}

	void FixedUpdate() {
		if (currentPunchDelay > punchDelay) {
			punchShockWave.SetActive(true);
			body2d.velocity = new Vector2 (waveSpeed, 0f);
			Invoke("Destroy", waveLifeTime); //destroy after set time if it doesn't collide
		}
		currentPunchDelay += Time.deltaTime;	
	}

	void OnEnable() {
		currentPunchDelay = 0f;
	}
		
	void Destroy() {
		punchShockWave.SetActive(false);
		gameObject.SetActive(false);
	}

	void OnDisable() {
		CancelInvoke();
	}
}
