using UnityEngine;
using System.Collections;

public class bossWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (FindObjectOfType<BossHealthMananger> ()) {
			return;
		}
		Destroy (gameObject);
	
	}
}
