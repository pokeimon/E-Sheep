using UnityEngine;
using System.Collections;

public class Chocolate : AbstractEnemy {
	public bool moveRight;
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;
	private bool notAtEdge;
	public Transform edgeCheck;

	private float ySize;
	//private float xSize;
	// Use this for initialization
	void Start (){
		speed = 3;
		jumpSpeed = 0;
		ySize = transform.localScale.y;

		} //target the player

	
	// Update is called once per frame
	void FixedUpdate () {
		//var tmpSpeed = speed;
	//	var velX = tmpSpeed * (float)direction;

		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);
		notAtEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsWall);
		if (hittingWall || !notAtEdge) {
			moveRight = !moveRight;
		}

		//body2d.velocity = new Vector2 (velX, body2d.velocity.y);
		if (moveRight) {
			transform.localScale = new Vector3(-ySize,transform.localScale.y,transform.localScale.z);
			body2d.velocity = new Vector2 (speed, body2d.velocity.y);
		} else {
			transform.localScale = new Vector3(ySize,transform.localScale.y,transform.localScale.z);
			body2d.velocity = new Vector2 (-speed, body2d.velocity.y);
		}


	}



	
}
