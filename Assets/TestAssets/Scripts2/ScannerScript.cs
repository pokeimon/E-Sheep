using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Scanner script. Connect to scanner child of player
/// </summary>
public class ScannerScript : MonoBehaviour {

	public List<GameObject> rangeList;

	// Use this for initialization
	void Awake () {
		rangeList = new List<GameObject> ();
	}
	
//	// Update is called once per frame
//	void Update () {
//	
//	}

}
