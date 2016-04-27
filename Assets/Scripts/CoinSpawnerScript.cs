using UnityEngine;
using System.Collections;

public class CoinSpawnerScript : MonoBehaviour {
	Transform[] coins;


	// Use this for initialization
	void Start () {
		coins = GetComponentsInChildren<Transform> ();
		//coins[0] is the coin container (CoinSpawner)
		for (int i = 1; i < coins.Length; i++) {
			coins [i].gameObject.SetActive (false);
		}
	}
	
	public void SpawnCoins(){
		Debug.Log ("SpawnCoins()");
		for (int i = 1; i < coins.Length; i++) {
			coins [i].gameObject.SetActive (true);
		}
	}
}
