﻿using UnityEngine;
using System.Collections;

public class Shoot : AbstractBehavior {

    public float shootDelay;
    public Vector2 firePosition = Vector2.zero;
    public Color debugColor = Color.yellow;
    public float debugRadius = 3.5f;
	public bool shooting = false;

    private float currentShootDelay = 0f;

	
	void Update () {

		if (health.currentHP > 1) {
			if(health.currentHP < 3){
				shootDelay = .3f;
			}
			else {
				shootDelay = .2f; //double fire speed for energy 3+
			}


			var shootButton = inputState.GetButtonValue (inputButtons [0]);
			var up = inputState.GetButtonValue (inputButtons [1]);
			var down = inputState.GetButtonValue (inputButtons [2]);

			if(shootButton){
				shooting = true; //shooting animation
			}
			else { 
				shooting = false;
			}


			if (shootButton && (currentShootDelay > shootDelay) && !collisionState.stunned) {
                GameObject obj = objectPooler.getPooledObject();

                if (obj != null){			
                    obj.transform.position = CalculateFirePosition();
                    obj.transform.rotation = transform.rotation;
                    obj.transform.localScale = transform.localScale * .2f;
					Rigidbody2D body2d = obj.GetComponent<Rigidbody2D>();
                    obj.SetActive(true);
					if (up && !down){
						body2d.velocity = new Vector2(body2d.velocity.y , Mathf.Abs(body2d.velocity.x));
					}
					else if (!up && down){
						body2d.velocity = new Vector2(body2d.velocity.y , Mathf.Abs(body2d.velocity.x) * -1);
					}
                    
                }
				currentShootDelay = 0;	 
			}
			currentShootDelay += Time.deltaTime;
		} 
	}

    Vector2 CalculateFirePosition() {
        var pos = firePosition;
        if(inputState != null)
            pos.x *= (float)inputState.direction;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        return pos;
    }

    void OnDrawGizmos() {
        var pos = firePosition;
        if(inputState != null)
            pos.x *= (float)inputState.direction;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        Gizmos.color = debugColor;
        Gizmos.DrawWireSphere(pos, debugRadius);
    }
}
