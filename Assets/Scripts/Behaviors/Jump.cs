using UnityEngine;
using System.Collections;

public class Jump : AbstractBehavior {

	public float jumpSpeed = 6f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var canJump = inputState.GetButtonValue (inputButtons [0]);

		//if (collisonState.standing) {
			if(canJump){
				OnJump();
			}
		}
	//}

	protected virtual void OnJump(){
		var vel = body2d.velocity;

		body2d.velocity = new Vector2 (vel.x, jumpSpeed);
	}
}
