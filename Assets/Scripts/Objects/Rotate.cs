﻿using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public bool right;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(right)
			transform.Rotate (0, 0, -.25f);
		else
			transform.Rotate (0, 0, .25f);
	}
}
