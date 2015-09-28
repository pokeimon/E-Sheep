using UnityEngine;
using System.Collections;

public class Jump : AbstractBehavior {

	public float jumpSpeed = 20f;
	//public Animator anim;

	// Use this for initialization
	void Start () {
		//anim = GetComponent<Animator> (); 
	}
	
	// Update is called once per frame
	void Update () {
		var canJump = inputState.GetButtonValue (inputButtons [0]);
        var holdTime = inputState.GetButtonHoldTime(inputButtons[0]);

		//anim.SetInteger("playerState", 0);
		if (collisionState.standing) {
			if(canJump && holdTime < .1f){
				OnJump();
				//anim.SetInteger("playerState", 2);
			}
		}
	}

	protected virtual void OnJump(){
		var vel = body2d.velocity;

		body2d.velocity = new Vector2 (vel.x, jumpSpeed);
	}
}
