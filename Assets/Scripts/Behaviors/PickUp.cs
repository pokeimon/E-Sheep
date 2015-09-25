using UnityEngine;
using System.Collections;

public class PickUp : AbstractBehavior {

	private int _currentItem = 0;
	public bool hasGun = false; 
	public Animator animator;

	public int currentItem{
		get{ return _currentItem;}
		set{ 
			_currentItem = value;
			animator.SetInteger("EquippedItem",_currentItem);
		}
	}

	override protected void Awake(){       
		base.Awake ();
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		Debug.Log ("Current Item = " + _currentItem);                      // This is all temporary code
		var B = inputState.GetButtonValue (inputButtons [0]);              // should be removed once our animation
		// problems are figured out
		if (_currentItem == 1) {
			if (B) {                                                       
				animator.SetInteger ("AnimState", 3); //shooting animation           
			}
		}
	}
}

