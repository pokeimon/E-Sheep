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
			anim.SetInteger ("gun", 1);//walking with gun animation
			if(Input.GetKeyDown("p")){
				anim.SetInteger ("gun", 5); //shooting animation
			}
		} else {
			anim.SetInteger ("gun", 0); //idle unarmed animation
			if(Input.GetKeyDown("space")){
				anim.SetInteger ("gun", 4); // jumping unarmed animation
			}
		}
        if (right || left)
        {


            if (hasGun)
            {
                anim.SetInteger("gun", 3);//walking with gun animation
                if (Input.GetKeyDown("p"))
                {
                    anim.SetInteger("gun", 5); //shooting animation
                }
            }
            else
            {
                anim.SetInteger("gun", 2); //walking unarmed animation
                if (Input.GetKeyDown("space"))
                {
                    anim.SetInteger("gun", 4);// jumping unarmed animation
                }
            }
     

            var tmpSpeed = speed;

            var velX = tmpSpeed * (float)inputState.direction;

            body2d.velocity = new Vector2(velX, body2d.velocity.y);
        }
        else
        {
            body2d.velocity = new Vector2(0f, body2d.velocity.y); //stops character from moving when no buttons pressed
        }
	}
	
	void OnCollisionEnter2D (Collision2D other) 
	{
		if (other.gameObject.tag == "Gun") { //picks up gun
			hasGun = true;
			other.gameObject.SetActive (false);
		}

	}


}
