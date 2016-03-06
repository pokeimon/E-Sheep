using UnityEngine;
using System.Collections;

public class GhostBlocks : MonoBehaviour {

	public Renderer rend;
	public Collider2D coll;
	private float blinkTime = 2.5f;
	
	void Start () {
		rend = GetComponent<Renderer> ();
		StartCoroutine("HideUnhide");
	}

	IEnumerator HideUnhide () {
		while (true) {
			yield return (new WaitForSeconds(blinkTime));
			rend.enabled = true;
			coll.enabled = true;
			yield return (new WaitForSeconds(blinkTime));
			rend.enabled = false;
			coll.enabled = false;
		}
	}
}