using UnityEngine;
using System.Collections;
//using UnityEngine.UI;

public class UIOverlay : MonoBehaviour {
	private GameObject player;
	private int currentHP;
	public GameObject[] hp;

	//public Vector3 screenPos;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		currentHP = player.GetComponent<Health> ().currentHP;
	}
	
	// Update is called once per frame
	void Update () {
		//screenPos = Camera.main.WorldToScreenPoint (transform.position);
		//screenPos.y = Screen.height - screenPos.y;

		currentHP = player.GetComponent<Health> ().currentHP;
		updateHP (currentHP);
	}
	/*
	void OnGUI () {
		GUI.Label (new Rect (screenPos.x - 36, screenPos.y - 35, Screen.width / 8, 7), hp[0]);
		GUI.Label (new Rect (screenPos.x - 36, screenPos.y - 35, Screen.width / 8, 7), hp[1]);
		GUI.Label (new Rect (screenPos.x - 36, screenPos.y - 35, Screen.width / 8, 7), hp[2]);
		GUI.Label (new Rect (screenPos.x - 36, screenPos.y - 35, Screen.width / 8, 7), hp[3]);
	} */

	//HP UI
	private void updateHP (int hpVal) {
		switch (hpVal) {
		//No Health
		case 0: 
			hp[0].GetComponent<SpriteRenderer>().enabled = false;
			hp[1].GetComponent<SpriteRenderer>().enabled = false;
			hp[2].GetComponent<SpriteRenderer>().enabled = false;
			hp[3].GetComponent<SpriteRenderer>().enabled = false;
			break;
		//One Health
		case 1:
			hp[0].GetComponent<SpriteRenderer>().enabled = true;
			hp[1].GetComponent<SpriteRenderer>().enabled = false;
			hp[2].GetComponent<SpriteRenderer>().enabled = false;
			hp[3].GetComponent<SpriteRenderer>().enabled = false;
			break;
		//Two Health
		case 2:
			hp[0].GetComponent<SpriteRenderer>().enabled = true;
			hp[1].GetComponent<SpriteRenderer>().enabled = true;
			hp[2].GetComponent<SpriteRenderer>().enabled = false;
			hp[3].GetComponent<SpriteRenderer>().enabled = false;
			break;
		//Three Health
		case 3:
			hp[0].GetComponent<SpriteRenderer>().enabled = true;
			hp[1].GetComponent<SpriteRenderer>().enabled = true;
			hp[2].GetComponent<SpriteRenderer>().enabled = true;
			hp[3].GetComponent<SpriteRenderer>().enabled = false;
			break;
		//Max Health
		case 4:
			hp[0].GetComponent<SpriteRenderer>().enabled = true;
			hp[1].GetComponent<SpriteRenderer>().enabled = true;
			hp[2].GetComponent<SpriteRenderer>().enabled = true;
			hp[3].GetComponent<SpriteRenderer>().enabled = true;
			break;
		default:
			break;
		}
	}
}

