using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private InputState inputState;
	private Walk walkBehavior;
	//private Animator animator;
	private CollisionState collisionState;

	void Awake(){
		inputState = GetComponent<InputState> ();
		walkBehavior = GetComponent<Walk> ();
		//animator = GetComponent<Animator> ();
		collisionState = GetComponent<CollisionState> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

	void Update () {
		if (collisionState.standing) { // Animations work allready I will consult with Ivan about how he wants to handle this -Steven
			ChangeAnimationState (0);
		}
		if (inputState.absVelX > 0) {
			ChangeAnimationState (1);
		}
	}

	void ChangeAnimationState(int value){
		//animator.SetInteger ("AnimState", value);
	}
}
