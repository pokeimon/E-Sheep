using UnityEngine;
using System.Collections;

public class PlayerSave : MonoBehaviour {


	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("Level") == null) {
			PlayerPrefs.SetInt ("Level", 3);
		}
		if (PlayerPrefs.GetInt ("Score") == null) {
			PlayerPrefs.SetInt ("Score", 0);
		}
		if (PlayerPrefs.GetInt ("HighScore") == null) {
			PlayerPrefs.SetInt ("HighScore", 0);
		}
	}

	void Update () {
		//HighScore updating
		if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt("HighScore")) {
			PlayerPrefs.SetInt ("HighScore", PlayerPrefs.GetInt ("Score"));
		}
	}


}
