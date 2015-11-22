using UnityEngine;
using System.Collections;

public class Mallow : AbstractEnemy {
	
	public Rigidbody2D mallow;
	public Transform target;
	public bool chase = false;

	void Start (){
		speed = 3f;
		jumpSpeed = 8f;
		mallow = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate (){  //Handles movement and jumps

		if (chase) {
			Debug.Log ("Entered");
			mallow.transform.position = Vector3.MoveTowards (mallow.transform.position, target.transform.position, Time.deltaTime * speed);
		}
		

		
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
	protected virtual void OnTriggerEnter2D(Collider2D target) {
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
	}

	protected virtual void OnJump(){

		var vel = body2d.velocity;
		
		body2d.velocity = new Vector2 (vel.x, jumpSpeed);
	}

}
