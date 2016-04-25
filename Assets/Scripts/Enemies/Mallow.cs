using UnityEngine;
using System.Collections;

public class Mallow : AbstractEnemy {
	
	public Transform mallow;
	public Transform target;
	public LayerMask chaseLayer;
	public float collisionRadius = 10f;
	public bool chase = false;
	public Vector2 mallowCenter = Vector2.zero;
	public Color debugCollisionColor = Color.red;

	void Start (){
		speed = 3f;
		jumpSpeed = 8f;
		mallow = GetComponent<Rigidbody2D> ().transform;
	}

	void FixedUpdate (){  //Handles movement and jumps

		var pos = mallowCenter;
		pos.x += transform.position.x;
		pos.y += transform.position.y;

		chase = Physics2D.OverlapCircle (pos, collisionRadius, chaseLayer);

		if (chase) {
			Debug.Log ("Mallow.cs FixedUpdate Entered");
			speed = 7;
			mallow.transform.position = Vector3.MoveTowards (mallow.position, target.transform.position, Time.deltaTime * speed);
		} else { speed = 3;}
		
		if ((Time.time % 2) == 0 && collisionState.standing) {
			OnJump ();
		}
		
		if (!chase) {
			var tmpSpeed = speed;
			var velX = tmpSpeed * (float)direction;
			body2d.velocity = new Vector2 (velX, body2d.velocity.y);


			if ((Time.time % 4) == 0 && direction == enemyDirections.Right) {
				//Debug.Log("Mallow direction changed: Left");"
				direction = enemyDirections.Left;
			}
		
			if ((Time.time % 8) == 0 && direction == enemyDirections.Left) {
				//Debug.Log("Mallow direction changed: Right");
				direction = enemyDirections.Right;
			}
		}
	}

	/*protected virtual void OnTriggerEnter2D(Collider2D target) {
		if (target.gameObject.tag == "Player") {
			chase = true;
			speed = 6f;
		}
	}
	protected virtual void OnTriggerExit2D(Collider2D target) {
		if (target.gameObject.tag == "Player") {
			chase = false;
			speed = 3f;
			Debug.Log("Exited");
		}
	}*/

	void OnDrawGizmos(){
		Gizmos.color = debugCollisionColor;
		
		var pos = mallowCenter;
		pos.x += transform.position.x;
		pos.y += transform.position.y;
		
		Gizmos.DrawWireSphere (pos, collisionRadius);
	}

	protected virtual void OnJump(){

		var vel = body2d.velocity;
		
		body2d.velocity = new Vector2 (vel.x, jumpSpeed);
	}

}
