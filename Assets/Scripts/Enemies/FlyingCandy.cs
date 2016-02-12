using UnityEngine;
using System.Collections;

//this is a temporary class. will have to readjust it to use AbstractEnemy
public class FlyingCandy : MonoBehaviour {

	Rigidbody2D myrigidbody;
	int layerToCollideWith;

	void Awake(){
		myrigidbody = gameObject.GetComponentInParent<Rigidbody2D> ();
		layerToCollideWith = 8;
	}

	void OnTriggerEnter2D(Collider2D other){//this one should prevent the monster from going outside the level
//		Debug.Log("Monster collision.");
		if(other.gameObject.layer.Equals(layerToCollideWith)){
			myrigidbody.velocity = new Vector2 (myrigidbody.velocity.x * -1, myrigidbody.velocity.y * -1);
		}

	}
}
