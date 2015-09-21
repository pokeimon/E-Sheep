using UnityEngine;
using System.Collections;

public class PeaShooter : Collectable {
	
	private int itemID = 1;
	public bool hasGun = false; 
	public Animator anim;
	
	override protected void OnCollect(GameObject target){       
		var pickUpBehavior = target.GetComponent<PickUp>();
		if(pickUpBehavior != null){
			pickUpBehavior.currentItem = itemID;
			}
	}
}
