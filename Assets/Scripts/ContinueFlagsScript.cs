using UnityEngine;
using System.Collections;

public class ContinueFlagsScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
//			Debug.Log ("This flag is on: " + transform.position.ToString());
			GameObject.Find ("DeathMenu").GetComponent<DeathMenu> ().respawnPoint = gameObject;

			PlayerPrefs.SetFloat ("RespawnX", transform.position.x);
			PlayerPrefs.SetFloat ("RespawnY", transform.position.y);
			PlayerPrefs.SetFloat ("RespawnZ", transform.position.z);
			PlayerPrefs.SetInt ("ContinueFlag", 1);

		}
	}
}
