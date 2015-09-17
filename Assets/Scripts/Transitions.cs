using UnityEngine;
using System.Collections;

public class Transitions : MonoBehaviour
{

    public Texture2D fadeTexture;   //The texture that will overlay the screen.  
    public float fadeSpeed = 0.8f;

    private int drawDepth = -1000;
    private float alpha = 1.0f; 
    private int fadeDirection;


    void OnGUI()
    {
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }
    public float FadeIn()
    {
        fadeDirection = -1;
        return fadeSpeed;
    }

    public float FadeOut()
    {
        fadeDirection = 1;
        return fadeSpeed;
    }

    void OnLevelWasLoaded()
    {
        FadeIn();
    }

}
    
