using UnityEngine;
using System.Collections;

public class GhostBlocks : MonoBehaviour {

	public Renderer rend;
	public Collider2D coll;
	
	void Start () {
		rend = GetComponent<Renderer> ();
		StartCoroutine("HideUnhide");
	}

	IEnumerator HideUnhide () {
		while (true) {
			yield return (new WaitForSeconds(2));
			rend.enabled = true;
			coll.enabled = true;
			yield return (new WaitForSeconds(2));
			rend.enabled = false;
			coll.enabled = false;
		}
	}
}