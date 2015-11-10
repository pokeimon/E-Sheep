using UnityEngine;
using System.Collections;

public class PickUp : AbstractBehavior {

	private int _currentItem = 0;
	private Animator animator;

	public int currentItem{
		get{ 
			return _currentItem;
		}
		set{ 
			_currentItem = value;
			animator.SetInteger("EquippedItem",_currentItem);
		}
	}

	override protected void Awake(){       
		base.Awake ();
		animator = GetComponent<Animator> ();
	}

	void Update () {
		//Debug.Log ("Current Item = " + _currentItem);                      // This is all temporary code
	}
}

