using UnityEngine;
using System.Collections;

public class Startup : MonoBehaviour {
	public float sceneTimeLegnth = 2.0f;
	// Use this for initialization
	void Start () {
		StartCoroutine(wait());
	}

	IEnumerator wait(){
		yield return new WaitForSeconds(sceneTimeLegnth);
		StartCoroutine(GameObject.Find("GM").GetComponent<Transitions>().FadeStartLevel(0));
	}

}
