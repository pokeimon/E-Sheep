using UnityEngine;
using System.Collections;

public class PeaShooter : Collectable {
	
	private int itemID = 1;
    public GameObject projectilePrefab;

	override protected void OnCollect(GameObject target){ 

		var pickUpBehavior = target.GetComponent<PickUp>();
		var shootBehavior = target.GetComponent<Shoot> ();

		if(pickUpBehavior != null) {
			pickUpBehavior.currentItem = itemID;
			} 	

        if(shootBehavior != null) {
            shootBehavior.projectilePrefab = projectilePrefab;
        }
	}
}
