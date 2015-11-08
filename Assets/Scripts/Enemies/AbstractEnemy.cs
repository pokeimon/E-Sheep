using UnityEngine;
using System.Collections;

public enum enemyDirections{ //Enemy direction
	Right = 1,         
	Left = -1          
}

public abstract class AbstractEnemy : MonoBehaviour {

	protected enemyDirections direction = enemyDirections.Right;
	protected float _jumpSpeed;
	protected float _speed;
	
	protected Rigidbody2D body2d;
	protected CollisionState collisionState;
	
	public float jumpSpeed{
		set{ _jumpSpeed = value;}
		get{return this._jumpSpeed;}
	}

	public float speed{
		set{ _speed = value;}
		get{return this._speed;}
	}

	protected virtual void Awake(){
		body2d = GetComponent<Rigidbody2D> ();
		collisionState = GetComponent<CollisionState> ();
	}

}
