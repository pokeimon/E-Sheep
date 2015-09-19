using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public Canvas exitMenu;
	//public Canvas creditMenu;
	//public Canvas optionsMenu;
	public Button startText;
	public Button optionsText;
	public Button creditsText;
	public Button exitText;

	// Use this for initialization
	void Start () {
		
		exitMenu = exitMenu.GetComponent<Canvas> ();
		//creditMenu = creditMenu.GetComponent<Canvas> ();
		//optionsMenu = optionsMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();

		exitMenu.enabled = false; //exit menu is disabled
		//creditMenu.enabled = false; //credit menu is disabled
		//optionsMenu.enabled = false; //options menu is disabled
		
	}
	
	//press exit button
	public void ExitPress() {
		
		exitMenu.enabled = true; //enable exit menu
		startText.enabled = false; //disable start button
		optionsText.enabled = false; //disable
		creditsText.enabled = false; //disable
		exitText.enabled = false; //disable
		
	}
	
	//go back to main menu when no is pressed in exit menu
	public void NoPress() {
		
		exitMenu.enabled = false;
		startText.enabled = true;
		optionsText.enabled = true;
		creditsText.enabled = true;
		exitText.enabled = true;
		
	}
	
	//goes to credit menu
	public void CreditPress() {
		//creditMenu.enabled = true;
		//mainMenu.enabled = true;
		
	}
	
	//go back to main menu
	public void MenuPress() {
		
		Application.LoadLevel (0); //loads menu
		
	}
	
	//press start game button
	public void StartLevel() {
		
		Application.LoadLevel (1); //loads game
		
	}
	
	//press yes to exit game
	public void ExitGame() {

		Application.Quit (); //quits game

	}

}
