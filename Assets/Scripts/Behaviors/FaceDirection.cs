using UnityEngine;
using System.Collections;

public class FaceDirection : AbstractBehavior {

	void Update () {
		var right = inputState.GetButtonValue (inputButtons [0]);
		var left = inputState.GetButtonValue (inputButtons [1]);

		if (right) {
			inputState.direction = Directions.Right;
		} 
		else if (left) {
			inputState.direction = Directions.Left;
		}
		transform.localScale = new Vector3 ((float)inputState.direction, 1, 1); // I dont understand how to not change the sprites size here.
	}
}
