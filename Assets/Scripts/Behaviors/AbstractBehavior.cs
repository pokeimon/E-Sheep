using UnityEngine;
using System.Collections;

public abstract class AbstractBehavior : MonoBehaviour {

	public Buttons[] inputButtons;

	protected InputState inputState;
	protected Rigidbody2D body2d;
	protected CollisionState collisionState;
	protected Health health;
	protected ObjectPooler objectPooler;

	protected virtual void Awake(){
		health = GetComponent<Health> ();
		inputState = GetComponent<InputState> ();
		body2d = GetComponent<Rigidbody2D> ();
		collisionState = GetComponent<CollisionState> ();
		objectPooler = GameObject.Find("PlayerBulletObjectPool").GetComponent<ObjectPooler> ();
	}
}
