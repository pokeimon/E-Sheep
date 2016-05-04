using UnityEngine;
using System.Collections;

public class PlayerPrefCheckScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			Debug.Log ("PlayerPrefs: " + PlayerPrefs.GetFloat ("RespawnX") + ", "
			+ PlayerPrefs.GetFloat ("RespawnY") + ", "
			+ PlayerPrefs.GetFloat ("RespawnZ"));

			Debug.Log ("Resetting to: 0,0,0");
			PlayerPrefs.SetFloat ("RespawnX", 0f);
			PlayerPrefs.SetFloat ("RespawnY", 0f);
			PlayerPrefs.SetFloat ("RespawnZ", 0f);
			PlayerPrefs.SetInt ("ContinueFlag", 0);
		}
	}
}
