using UnityEngine;
using System.Collections;

public class PickUp : AbstractBehavior {

	private int _currentItem = 0;
	public bool hasGun = false; 
	public Animator anim;

	public int currentItem{
		get{ return _currentItem;}
		set{ 
			_currentItem = value;
		//	Animator.SetInteger("EquippedItem",_currentItem);
		}
	}

	/*overide protected void Awake(){       //This is how the lynda tutorial handles animation will disucss Wed
		base.Awake ();
		anim = GetComponent<Animator> ();
	}*/

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> (); 
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log ("Current Item = " + _currentItem);                      // This is all temporary code
		var B = inputState.GetButtonValue (inputButtons [0]);              // should be removed once our animation
		                                                                   // problems are figured out
		if (_currentItem == 1) {
			anim.SetInteger ("gun", 1);//walking with gun animation        //
			if(B){                                                       
				anim.SetInteger ("gun", 5); //shooting animation           //
			}
		} else {                                                           //
			anim.SetInteger ("gun", 0); //idle unarmed animation
			if(Input.GetKeyDown("space")){                                 //
				anim.SetInteger ("gun", 4); // jumping unarmed animation
			}
		}
	}

	/*void OnCollisionEnter2D (Collision2D other) 
	{
		if (other.gameObject.tag == "Gun") { //picks up gun
			hasGun = true;
			other.gameObject.SetActive (false);
		}
	}*/
}
