using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Wisp pool script.
/// Uses Aaron's Object Pool script as a basis
/// </summary>
public class WispPoolScript : MonoBehaviour {
	public static WispPoolScript current;
	public GameObject pooledObject;
	public int pooledAmount = 10;
//	public bool willGrow = true;

	List<GameObject> pooledObjects;

	void Awake(){
		current = this;
	}

	void Start (){
		pooledObjects = new List<GameObject> (); 

		//Create Clones
		for(int i = 0; i < pooledAmount; i++){
			GameObject obj = (GameObject)Instantiate (pooledObject);
			obj.SetActive(false);
			pooledObjects.Add (obj);
		}
	}

	/// <summary>
	/// Gets the first available (non-active) pooled object.
	/// Returns null if there are no available objects.
	/// </summary>
	/// <returns>The pooled object.</returns>
	public GameObject getPooledObject() {
		for (int i = 0; i < pooledObjects.Count; i++){
			if(!pooledObjects[i].activeInHierarchy){
				return pooledObjects[i];
			}	
		}


		return null;
	}

}
