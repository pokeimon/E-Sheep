using UnityEngine;
using System.Collections;

/// <summary>
/// Summon wisp script. Links instantiating wisps with trigger button
/// </summary>
public class SummonWispScript : AbstractBehavior {

	public GameObject wisp;
//	// Use this for initialization
//	void Awake () {
//		
//	}
	
	// Update is called once per frame
	void Update () {
		var triggerButton = inputState.GetButtonValue (inputButtons [0]);
		if (triggerButton) {
			if (inputState.GetButtonHoldTime (inputButtons [0]) < .01f) {//keeps flickering to a minimum
				WispPoolScript.current.getPooledObject().SetActive(true);
			}
		}
	}
}