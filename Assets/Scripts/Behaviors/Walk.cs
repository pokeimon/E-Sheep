﻿using UnityEngine;
using System.Collections;

public class Walk : AbstractBehavior {

	public float speed = 7f;
	public Animator anim;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		var right = inputState.GetButtonValue (inputButtons [0]);
		var left = inputState.GetButtonValue (inputButtons [1]);
		
        if (right || left)
        {
            var tmpSpeed = speed;

            var velX = tmpSpeed * (float)inputState.direction;

            body2d.velocity = new Vector2(velX, body2d.velocity.y);
        }
        else
        {
            body2d.velocity = new Vector2(0f, body2d.velocity.y); //stops character from moving when no buttons pressed
        }
	}
}
