using UnityEngine;
using System.Collections;

public class GhostBlocks : MonoBehaviour {

	public Renderer rend;
	
	void Start () {  
		rend = GetComponent<Renderer> ();
		StartCoroutine("HideUnhide");
	}


	IEnumerator HideUnhide () {
		while (true) {
			yield return (new WaitForSeconds(2));
			rend.enabled = true;
			yield return (new WaitForSeconds(2));
			rend.enabled = false;
		}
	}
}