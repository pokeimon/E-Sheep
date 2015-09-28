using UnityEngine;
using System.Collections;

public class PeaShooter : Collectable {
	
	private int itemID = 1;
    public GameObject projectilePrefab;

	public bool hasGun = false; 
	public Animator anim;
	
	override protected void OnCollect(GameObject target){       
		var pickUpBehavior = target.GetComponent<PickUp>();
		if(pickUpBehavior != null) {
			pickUpBehavior.currentItem = itemID;
			}

        
        var shootBehavior = target.GetComponent<Shoot>();
        if(shootBehavior != null) {
            shootBehavior.projectilePrefab = projectilePrefab;
        }
        
	}
}
