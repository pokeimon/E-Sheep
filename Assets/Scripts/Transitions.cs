using UnityEngine;
using System.Collections;

public class Transitions : MonoBehaviour
{

    public Texture2D fadeTexture;   //The texture that will overlay the screen.  
    public float fadeSpeed = 0.8f;	

    private int drawDepth = -1000;
    private float alpha = 0.0f; 	
    private int fadeDirection = -1; //-1 fadeIn or 1 fadeOut


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
		alpha = 1.0f;
        fadeDirection = -1;
        return fadeSpeed;
    }

	/*used to fadeOut the scene (typcally used at the end of a scene)
	fadeSpeed is returned to use to time the transition of scenes*/
    public float FadeOut(){
		alpha = 0.0f;
        fadeDirection = 1;
        return fadeSpeed;
    }

	/*This function is called after a new level was loaded.
	the level is the current level it is loading.  
	This will be used to pick which levels to transitions and which not too.*/
    void OnLevelWasLoaded(int level)
    {
		Debug.Log ("Test");
		if(level!=0){
			FadeIn ();
		}
		else {
			fadeDirection = 1;
			alpha = 1.0f;
		}
    }
}
    
