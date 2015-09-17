using UnityEngine;
using System.Collections;

public class Walk : AbstractBehavior {

	public float speed = 5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		var right = inputState.GetButtonValue (inputButtons [0]);
		var left = inputState.GetButtonValue (inputButtons [1]);

		if (right || left) {

			if (left){
				inputState.direction = Directions.Left;
			} else if (right) {
				inputState.direction = Directions.Right;
			}

			var tmpSpeed = speed;

			var velX = tmpSpeed * (float)inputState.direction;

			body2d.velocity = new Vector2 (velX, body2d.velocity.y);
		}
	}
}
