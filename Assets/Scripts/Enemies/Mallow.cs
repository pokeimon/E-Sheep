using UnityEngine;
using System.Collections;

public class Mallow : AbstractEnemy {
	
	float speed = 3f;
	float jumpSpeed = 8f;
	int maxHP = 5;

	// Update is called once per frame
	void Update () {

		}

	void FixedUpdate (){                                                      //Handles movement and jumps

		var tmpSpeed = speed;
		var velX = tmpSpeed * (float)direction;
		
		body2d.velocity = new Vector2(velX, body2d.velocity.y);
		
		if ((Time.time % 2) == 0) {
			OnJump ();
		}
		
		if ((Time.time % 4) == 0 && direction == enemyDirections.Right) {
			
			//Debug.Log("Mallow direction changed: Left");
			direction = enemyDirections.Left;
		}
		
		if((Time.time % 8) == 0 && direction == enemyDirections.Left){
			//Debug.Log("Mallow direction changed: Right");
			direction = enemyDirections.Right;
		}
	}

	protected virtual void OnJump(){

		var vel = body2d.velocity;
		
		body2d.velocity = new Vector2 (vel.x, jumpSpeed);
	}

}
