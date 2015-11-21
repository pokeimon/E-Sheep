using UnityEngine;
using System.Collections;

public class CallDeath : MonoBehaviour {

//	void onTriggerEnter2D(Collider2D col){
//		Debug.Log ("CallDeath on " + col.gameObject.name);
//		if(col.gameObject.name.Equals ("Player")){
//			col.gameObject.GetComponent<Health>().currentHP=0;
//
//		}
//
//	}
//	void onTriggerStay2D(Collider2D col){
//		Debug.Log ("CallDeath on " + col.gameObject.name);
//		if(col.gameObject.name.Equals ("Player")){
//
//			
//		}
//		
//	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name.Equals ("Player")){
			Debug.Log ("Abyss touched.");
			col.gameObject.GetComponent<Health>().currentHP=0;
		}
	}

}
