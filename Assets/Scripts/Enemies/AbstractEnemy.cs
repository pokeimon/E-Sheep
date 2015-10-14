using UnityEngine;
using System.Collections;

public enum enemyDirections{ //Enemy direction
	Right = 1,         
	Left = -1          
}

public abstract class AbstractEnemy : MonoBehaviour {

	public int maxHP = 5;
	public int currentHP;

	protected enemyDirections direction = enemyDirections.Right;
	protected float jumpSpeed;
	protected float speed;


	protected Rigidbody2D body2d;
	protected CollisionState collisionState;

	protected virtual void Awake(){
		body2d = GetComponent<Rigidbody2D> ();
		collisionState = GetComponent<CollisionState> ();
	}

	public void Start (){
		currentHP = maxHP;
	}

	void OnCollisionEnter2D(Collision2D target) {
		if (target.gameObject.tag == "Bullet") {
			currentHP -= 1;
		}
		if (currentHP < 1) {
			gameObject.SetActive(false);
		}
	}
}
