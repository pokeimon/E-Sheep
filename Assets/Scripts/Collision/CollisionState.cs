using UnityEngine;
using System.Collections;

public class CollisionState : MonoBehaviour {

	public LayerMask collisionLayer;
	public LayerMask collisionBounce;
	public LayerMask collisionClimb;
	public bool climbing;
	public bool standing;
	public bool onBouncePad;
	public bool stunned;
	public float maxStunTime = 0.5f;
	public float timeStunned = 0;

	public Vector2 bottomPosition = Vector2.zero;
	public float collisionRadius = 0.25f;
	public Color debugCollisionColor = Color.red;


	void FixedUpdate(){

		var pos = bottomPosition;
		pos.x += transform.position.x;
		pos.y += transform.position.y;

		if (stunned) {
			timeStunned += Time.deltaTime;
			if (timeStunned > maxStunTime) {
				stunned = false;
			}	
		}
			
		climbing = Physics2D.OverlapCircle (pos, collisionRadius, collisionClimb);
		standing = Physics2D.OverlapCircle (pos, collisionRadius, collisionLayer);
		onBouncePad = Physics2D.OverlapCircle (pos, collisionRadius, collisionBounce);

	}

	void OnDrawGizmos(){
		Gizmos.color = debugCollisionColor;

		var pos = bottomPosition;
		pos.x += transform.position.x;
		pos.y += transform.position.y;

		Gizmos.DrawWireSphere (pos, collisionRadius);
	}
}
