using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public Canvas exitMenu;
	public Canvas creditMenu;

	public Button startText;
	public Button exitText;
	public Button mainMenuText;

	// Use this for initialization
	void Start () {
		
		exitMenu = exitMenu.GetComponent<Canvas> ();
		creditMenu = creditMenu.GetComponent<Canvas> ();

		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		mainMenuText = mainMenuText.GetComponent<Button> ();

		exitMenu.enabled = false; //exit menu is disabled
		creditMenu.enabled = false; //credit menu is disabled
		
	}
	
	//press exit button
	public void ExitPress() {
		
		exitMenu.enabled = true; //enable exit menu
		startText.enabled = false; //disable start button
		exitText.enabled = false; //disable
		
	}
	
	//go back to main menu when no is pressed in exit menu
	public void NoPress() {
		
		exitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;

	}
	
	//goes to credit menu
	public void CreditPress() {

		creditMenu.enabled = true;
		mainMenuText.enabled = true;
		
	}
	
	//go back to main menu
	public void MenuPress() {

		creditMenu.enabled = false;

	}
	
	//press start game button
	public void StartLevel() {
		StartCoroutine(GameObject.Find("GM").GetComponent<Transitions>().FadeStartLevel(2));
		
	}
	
	//press yes to exit game
	public void ExitGame() {

		Application.Quit (); //quits game

	}

}
