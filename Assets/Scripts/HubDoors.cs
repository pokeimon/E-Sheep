using UnityEngine;
using System.Collections;

public class HubDoors : MonoBehaviour {
	
	public GameObject[] doors;

	private int levelsCompeted; 


	// Use this for initialization
	void Start () {
		levelsCompeted = PlayerPrefs.GetInt("Level"+PlayerPrefs.GetInt("SelectedPlayer"));
	}
	
	// Update is called once per frame
	void Update () {
		switch (levelsCompeted) {
		case 0:
			doors [0].SetActive(true);
			doors [1].SetActive(false);
			doors [2].SetActive(false);
			break;
		case 1:
			doors [0].SetActive(true);
			doors [1].SetActive(true);
			doors [2].SetActive(false);
			break;
		case 2:
			doors [0].SetActive(true);
			doors [1].SetActive(true);
			doors [2].SetActive(true);
			break;
		default: //this is used in case of bugs, enables all doors
			doors [0].SetActive(true);
			doors [1].SetActive(true);
			doors [2].SetActive(true);
			break;
			
		}
	}
}
