using UnityEngine;
using System.Collections;

public class Chocolate : AbstractEnemy {

	// Use this for initialization

		new void Start (){
			maxHP = 5;
			speed = 3f;
			base.Start ();
		} //target the player

	
	// Update is called once per frame
	void FixedUpdate () {
		var tmpSpeed = speed;
		var velX = tmpSpeed * (float)direction;
		
		body2d.velocity = new Vector2(velX, body2d.velocity.y);
		
		if ((Time.time % 4) == 0 && direction == enemyDirections.Right) {
			//Debug.Log("Mallow direction changed: Left");
			direction = enemyDirections.Left;
		}
		
		if((Time.time % 8) == 0 && direction == enemyDirections.Left){
			//Debug.Log("Mallow direction changed: Right");
			direction = enemyDirections.Right;
		}
	}
	
	protected virtual void OnTriggerEnter2D(Collider2D target) {
		if (target.gameObject.tag == "Player") {
			speed = 15f;
		}
	}
	protected virtual void OnTriggerExit2D(Collider2D target) {
		if (target.gameObject.tag == "Player") {
			speed = 3f;
		}
	}
	

	
}
