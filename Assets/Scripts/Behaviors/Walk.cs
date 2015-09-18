using UnityEngine;
using System.Collections;

public class Walk : AbstractBehavior {

	public float speed = 7f;
	public Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> (); 
	}
	
	// Update is called once per frame
	void Update () {
	
		var right = inputState.GetButtonValue (inputButtons [0]);
		var left = inputState.GetButtonValue (inputButtons [1]);

		anim.SetInteger ("playerState", 0);//idle state in animator controller
		if (right || left) {

			anim.SetInteger ("playerState", 1);//walking state in animator controller 
			//if (left){                                 // Works without this when FaceDirection 
			//	inputState.direction = Directions.Left;  // Script is added to character.
			//} else if (right) {                        //  
			//	inputState.direction = Directions.Right; //
			//}

			var tmpSpeed = speed;

			var velX = tmpSpeed * (float)inputState.direction;

			body2d.velocity = new Vector2 (velX, body2d.velocity.y);
		}
	}
}
