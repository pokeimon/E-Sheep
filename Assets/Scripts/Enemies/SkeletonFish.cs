using UnityEngine;
using System.Collections;

public class SkeletonFish : MonoBehaviour {
	private Rigidbody2D body2d;

	public LayerMask collisionLayer;
	public Vector2 platformDetect = Vector2.zero;
	public float collisionRadius = 0.25f;
	public Color debugCollisionColor = Color.red;

	public bool jump = false;
	public bool jumped = false;

	void Awake (){
		body2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		var pos = platformDetect;
		pos.x += transform.position.x;
		pos.y += transform.position.y;

		jump = Physics2D.OverlapCircle (pos, collisionRadius, collisionLayer);
		if (jump & !jumped) {
			body2d.velocity = new Vector2(-12f,20f);
			jumped = true;
		}
	}
	
	void OnDrawGizmos(){
		Gizmos.color = debugCollisionColor;

		var pos = platformDetect;
		pos.x += transform.position.x;
		pos.y += transform.position.y;

		Gizmos.DrawWireSphere (pos, collisionRadius);
	}

	void OnCollisionEnter2D(Collision2D target) {
		if (target.gameObject.tag == "Player") {
			Destroy ();
		}
	}

	void Destroy() {
		gameObject.SetActive(false);
	}

	void OnDisable() {
		CancelInvoke();
	}
}
