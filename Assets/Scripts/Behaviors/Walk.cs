using UnityEngine;
using System.Collections;

public class Walk : AbstractBehavior {

	public float maxSpeed = 7f;
	public float acceleration = 2f;
	public float runMultiplyer = 2f;

	private float velX;

	void Update () {
		var right = inputState.GetButtonValue (inputButtons [0]);
		var left = inputState.GetButtonValue (inputButtons [1]);
		var X = inputState.GetButtonValue (inputButtons [2]);

		if ((right || left) && !collisionState.stunned){
			float tempAccel = acceleration;

			if (X && runMultiplyer > 0 && !collisionState.climbing) {
				tempAccel = tempAccel * runMultiplyer * (float)inputState.direction;
				velX = tempAccel + body2d.velocity.x;
				if (Mathf.Abs(velX) > maxSpeed * runMultiplyer) { //limit speed
					velX = maxSpeed * runMultiplyer * (float)inputState.direction;
				}
			}
			else {
				tempAccel = tempAccel * runMultiplyer * (float)inputState.direction;
				velX = tempAccel + body2d.velocity.x;
				if (Mathf.Abs(velX) > maxSpeed) { //limit speed
					velX = maxSpeed * (float)inputState.direction;
				}
			}

			body2d.velocity = new Vector2(velX, body2d.velocity.y);
        }
		else if (!collisionState.stunned){
        	body2d.velocity = new Vector2(0f, body2d.velocity.y); //stops character from moving when no buttons pressed
        }

	}

	/* detects when the player is on the moving platform
	 * and makes the player move with the platform
	 */
	void OnCollisionEnter2D(Collision2D other){
		if(other.transform.tag == "Moving Platform"){
			transform.parent = other.transform;
		}
	}

	/* detects when the player leaves the moving platform
	 * and makes the player stop moving with the platorm
	 */
	void OnCollisionExit2D(Collision2D other){
		if(other.transform.tag == "Moving Platform"){
			transform.parent = null;
		}
	}
}
