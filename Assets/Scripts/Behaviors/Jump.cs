using UnityEngine;
using System.Collections;

public class Jump : AbstractBehavior {

	public float jumpSpeed = 20f;
	public int extraJumps = 1;
	public int currentJump;
	private bool canJump;

	
	void Start() {
		currentJump = 0;
		canJump = true;
	}

	void Update () {
		var jumpButton = inputState.GetButtonValue (inputButtons [0]);
        var holdTime = inputState.GetButtonHoldTime(inputButtons[0]);

		if (!jumpButton) {
			canJump = true;
		}

		if (collisionState.standing || collisionState.climbing) {
			currentJump = 0;

			if (jumpButton && canJump) {
				OnJump ();
				canJump = false;
			}
		} 

		else if (currentJump < extraJumps) {
			if (jumpButton && canJump) {
				OnJump ();
				canJump = false;
				currentJump++;
			}
		}

	}

	protected virtual void OnJump(){
		var vel = body2d.velocity;

		body2d.velocity = new Vector2 (vel.x, jumpSpeed);
	}
}
