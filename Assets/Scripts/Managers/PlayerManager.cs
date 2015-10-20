using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	private InputState inputState;
	private Walk walkBehavior;
	private Animator animator;
	private CollisionState collisionState;
	private Shoot shootBehavior;
	private Climb climbBehavior;

	void Awake(){
		inputState = GetComponent<InputState> ();
		walkBehavior = GetComponent<Walk> ();
		animator = GetComponent<Animator> ();
		collisionState = GetComponent<CollisionState> ();
		shootBehavior = GetComponent<Shoot> ();
		climbBehavior = GetComponent<Climb> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Character animation

	void Update () {

		int caseSwitch = 0;

		if (inputState.absVelX > 0 && collisionState.standing) { // walking
			if(shootBehavior.shooting){
				caseSwitch = 3;
			} else {caseSwitch = 1;}
		}
		if (!collisionState.standing) { // jumping
			if(shootBehavior.shooting){
				caseSwitch = 3;
			} else {caseSwitch = 2;}
		}
		if (shootBehavior.shooting) { // shooting
			caseSwitch = 3;
		}

		if(climbBehavior.onLadder){ //climbing
			caseSwitch = 4;
		}

		switch (caseSwitch)
		{
		case 1:
			ChangeAnimationState (1); //walking
			break;
		case 2:
			ChangeAnimationState (2); // jumping
			break;
		case 3:
			ChangeAnimationState (3); // shooting
			break;
		case 4:
			ChangeAnimationState (4); // shooting
			break;
		default:
			ChangeAnimationState (0); // idle
			break;
		}
	}

	void ChangeAnimationState(int value){
		animator.SetInteger ("AnimState", value);
	}
}
