using UnityEngine;
using System.Collections;

public class PadBounce : AbstractBehavior {

	public float bounceSpeed = 15f;

	void Update () {
		var jumpButton = inputState.GetButtonValue (inputButtons [0]);

		if (collisionState.onBouncePad) {                     //Checks if on bounce pad, if true runs OnBounce if jump is pressed bounce speed is increased
			if (jumpButton && collisionState.onBouncePad){
				bounceSpeed = 30f;
			}
			OnBounce();
			bounceSpeed = 15f;
		}
	}

	protected virtual void OnBounce(){
		var vel = body2d.velocity;	
		body2d.velocity = new Vector2 (vel.x, bounceSpeed);
	}
}
