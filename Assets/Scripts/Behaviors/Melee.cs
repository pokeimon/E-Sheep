using UnityEngine;
using System.Collections;

public class Melee : AbstractBehavior {

	public float meleeDelay = 1f;
	public bool melee = false;
	private bool canMelee;
	private float currentMeleeDelay = 0f;

	void Update () {


		var meleeButton = inputState.GetButtonValue (inputButtons [0]);

		if (meleeButton) { //melee animation
			melee = true;
		} 
		else {
			canMelee = true; //must let go of button to melee again
			melee = false;
		}

		if (meleeButton && canMelee && (currentMeleeDelay > meleeDelay)) {
			GameObject sword = transform.GetChild(0).gameObject;
			sword.SetActive(true); //swing sword and reset for delay
			canMelee = false;
			currentMeleeDelay = 0;
		}
		currentMeleeDelay += Time.deltaTime;

	}

}
