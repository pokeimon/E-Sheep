using UnityEngine;
using System.Collections;

public class HorrorLandBoss : MonoBehaviour {


	void Update () {
	
	}

	void Shoot(){

	}

	void Melee(){
		GameObject sword = transform.GetChild(0).gameObject;
		sword.SetActive(true); //swing sword and reset for delay
	}
}
