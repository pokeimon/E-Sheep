﻿using UnityEngine;
using System.Collections;

public class Transitions : MonoBehaviour
{

    public Texture2D fadeTexture;   //The texture that will overlay the screen.  
    public float fadeSpeed = 0.8f;	

	private GameObject player;
    private int drawDepth = -1000;
    private float alpha = 0.0f; 	
    private int fadeDirection = -1; //-1 fadeIn or 1 fadeOut

	void OnEnable(){
		player = GameObject.Find("Player");

	}

	//used to disable or enable player input while/after transitioning
	void disableInput(bool disable){
		int current = Application.loadedLevel;

		if(current != 1){										//prevents running on main menu
			if(disable){										//disables player input
				if (!(player == null)) {
					player.GetComponent<Jump> ().enabled = false;
					player.GetComponent<Walk> ().enabled = false;
					player.GetComponent<Shoot> ().enabled = false;
					player.GetComponent<Melee> ().enabled = false;
				}
			}
			else{												//enables player input
				if (!(player == null)) {
					player.GetComponent<Jump> ().enabled = true;
					player.GetComponent<Walk> ().enabled = true;
					player.GetComponent<Shoot> ().enabled = true;
					player.GetComponent<Melee> ().enabled = true;
				}
			}
		}

	}

    void OnGUI(){
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);												//keeps the fading within 0 to 1
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);	//fills the screen with the texture
    }

	/*used to fadIn the scene (typcally used at the start of a scene)
	fadeSpeed is returned to use to time the transition of scenes*/
    public float FadeIn(){
		disableInput(false);
		alpha = 1.0f;
        fadeDirection = -1;
        return fadeSpeed;
    }

	/*used to fadeOut the scene (typcally used at the end of a scene)
	fadeSpeed is returned to use to time the transition of scenes*/
    public float FadeOut(){
		disableInput(true);
		alpha = 0.0f;
        fadeDirection = 1;
        return fadeSpeed;
    }

	/*This function is called after a new level was loaded.
	the level is the current level it is loading.  
	This will be used to pick which levels to transitions and which not too.*/
    void OnLevelWasLoaded(int level)
    {
		if(level!=null){		//replace null with the int of levels/scenes that should not fade in
			FadeIn ();
		}
    }

	public IEnumerator FadeStartLevel(int i){
		float fadeTime = GameObject.Find("GM").GetComponent<Transitions>().FadeOut();
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(i);
	}
}
    
