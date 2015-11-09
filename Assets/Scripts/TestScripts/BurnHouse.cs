using UnityEngine;
using System.Collections;

/*
This script is attached to a gameobject (branch)
It simulates a branch snapping off.
*/
public class BurnHouse : MonoBehaviour
{
//	private Rigidbody2D breakrigidbody2d;
	SpriteRenderer parentSpriteRenderer;

	void Start(){
		parentSpriteRenderer = gameObject.GetComponentInParent<SpriteRenderer> ();
	}
	
	//When the player enters the trigger collider, drop this object's rigidbody
	void OnTriggerEnter2D(Collider2D other)
	{
		//        Debug.Log("Trigger Entered");
		if (other.name == "Player")
		{
			Debug.Log ("BurnHouse triggered.");
			parentSpriteRenderer.color = Color.red;
			
		}
	}
	
//	//When the object's rigidbody exits the trigger collider, disable it (otherwise it'll get in the player's way)
//	void OnTriggerExit2D(Collider2D other)
//	{
//		if (other.name == "Breakable Branch")
//		{
//			other.gameObject.SetActive(false);
//			other.GetComponentInParent<BoxCollider2D>().enabled = false;
//		}
//		
//	}
}

