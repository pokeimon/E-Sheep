using UnityEngine;
using System.Collections;

public class ContinueScript : MonoBehaviour {

	void Awake(){
		//check PlayerPrefs
		if (Application.loadedLevelName.Equals ("Horror Land")) {
//			Debug.Log ("I have awoken!");
			if (PlayerPrefs.GetInt ("ContinueFlag") == 1) {
//				Debug.Log ("Here I am!");
				Vector3 newRespawn = new Vector3 (
					                     PlayerPrefs.GetFloat ("RespawnX"),
					                     PlayerPrefs.GetFloat ("RespawnY"),
					                     PlayerPrefs.GetFloat ("RespawnZ")
				                     );

				GameObject.Find ("Player").transform.position = newRespawn;
			}
		} else {
			PlayerPrefs.SetFloat ("RespawnX", 0f);
			PlayerPrefs.SetFloat ("RespawnY", 0f);
			PlayerPrefs.SetFloat ("RespawnZ", 0f);
			PlayerPrefs.SetInt ("ContinueFlag", 0);
		}
	}


}
