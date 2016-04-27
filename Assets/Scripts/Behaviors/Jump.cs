using UnityEngine;
using System.Collections;

public class Jump : AbstractBehavior {

	public float jumpSpeed = 20f;
	public int extraJumps = 1;
	public int currentJump;
	private bool canJump;
	private AudioSource jumpSoundEffect;

	void Start() {
		currentJump = 0;
		canJump = true;
		jumpSoundEffect = GetComponent<AudioSource> ();
	}

	void Update () {
		var jumpButton = inputState.GetButtonValue (inputButtons [0]);

		if (!jumpButton) {
			canJump = true;
		}

		if (collisionState.standing || collisionState.climbing) {
			currentJump = 0;
			if (jumpButton && canJump && !collisionState.stunned) {
				OnJump ();
				canJump = false;
			}
		} 

		else if ((currentJump < extraJumps)&& !collisionState.stunned) {
			if (jumpButton && canJump) {
				OnJump ();
				canJump = false;
				currentJump++;
			}
		}

	}

	protected virtual void OnJump(){
		var vel = body2d.velocity;
		jumpSoundEffect.Play ();
		body2d.velocity = new Vector2 (vel.x, jumpSpeed);
	}
}
