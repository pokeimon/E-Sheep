using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {

	private Animator anim;
	public bool isFading = false; // used for determining how long to yeild for

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> (); // reference to animator type
	}

	public IEnumerator FadeToClear() {
		isFading = true;
		anim.SetTrigger ("FadeIn");

		while (isFading) // will not return until isFading is back at false
			yield return null;
	}

	public IEnumerator FadeToBlack() {
		isFading = true;
		anim.SetTrigger ("FadeOut");
		
		while (isFading) // will not return until isFading is back at false
			yield return null;
	}
	
	void AnimationComplete() {
		isFading = false; //false
	}
}
