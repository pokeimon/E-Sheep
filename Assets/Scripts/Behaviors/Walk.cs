using UnityEngine;
using System.Collections;

public class Walk : AbstractBehavior {

	public float speed = 7f;
	public Animator anim;

	public bool hasGun = false; 
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> (); 
	}
	
	// Update is called once per frame
	void Update () {
	
		var right = inputState.GetButtonValue (inputButtons [0]);
		var left = inputState.GetButtonValue (inputButtons [1]);

		if (hasGun) {
			anim.SetInteger ("gun", 1);//walking state in animator controller 
			if(Input.GetKeyDown("s")){
				anim.SetInteger ("gun", 5);
			}
		} else {
			anim.SetInteger ("gun", 0);
			if(Input.GetKeyDown("s")){
				anim.SetInteger ("gun", 4);
			}
		}
		if (right || left) {


			if(hasGun){
				anim.SetInteger ("gun", 3);//walking state in animator controller 
				if(Input.GetKeyDown("s")){
					anim.SetInteger ("gun", 5);
				}
			}
			else{
				anim.SetInteger("gun", 2);
				if(Input.GetKeyDown("s")){
					anim.SetInteger ("gun", 4);
				}
			}
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
	
	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Gun") {
			hasGun = true;
			other.gameObject.SetActive (false);
		}

	}


}
