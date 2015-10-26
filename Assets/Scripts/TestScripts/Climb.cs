using UnityEngine;
using System.Collections;

public class Climb : AbstractBehavior {

    public float climbSpeed;
    private float climbVelocity;
    private float gravityStore;

    // Use this for initialization
    void Start () {

		gravityStore = body2d.gravityScale;
        //Debug.Log("GravityStore = " + gravityStore);
    }


    void Update()
    {
		var up = inputState.GetButtonValue (inputButtons [0]);
		var down = inputState.GetButtonValue (inputButtons [1]);

        //Debug.Log("onLadder? " + onLadder);
		if (collisionState.climbing)
        {
			body2d.gravityScale = 0f;

			if (up && !down){
				climbVelocity = climbSpeed ;
			}
			else if (!up && down){
				climbVelocity = climbSpeed * -1;
			}
			else { //won't climb if up and down held
				climbVelocity = 0;
			}

			body2d.velocity = new Vector2(body2d.velocity.x, climbVelocity);

        }
        else
        {
			body2d.gravityScale = gravityStore;
        }
    }
}
