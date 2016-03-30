using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public Canvas exitMenu;
	public Canvas creditMenu;
	public Canvas scoreMenu;

	public Button startText;
	public Button exitText;
	public Button mainMenuText;
	public Button newGameText;
	public Button scoreText;

	public GameObject gm;

	public Text score0;
	public Text score1;
	public Text score2;
	public Text score3;


	// Use this for initialization
	void Start () {
		gm = GameObject.Find("GM");

		exitMenu = exitMenu.GetComponent<Canvas> ();
		creditMenu = creditMenu.GetComponent<Canvas> ();
		scoreMenu = scoreMenu.GetComponent<Canvas> ();

		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		mainMenuText = mainMenuText.GetComponent<Button> ();
		newGameText = newGameText.GetComponent<Button> ();
		scoreText = scoreText.GetComponent<Button> ();

		exitMenu.enabled = false; //exit menu is disabled
		creditMenu.enabled = false; //credit menu is disabled
		scoreMenu.enabled = false;

	}
	
	//press exit button
	public void ExitPress() {
		
		exitMenu.enabled = true; //enable exit menu
		startText.enabled = false; //disable start button
		exitText.enabled = false; //disable
		newGameText.enabled = false; //disable
		
	}
	
	//go back to main menu when no is pressed in exit menu
	public void NoPress() {
		
		exitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
		newGameText.enabled = true;

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

	//go to character selection scene
	public void NewGamePress() {
		Application.LoadLevel (5);

	}
	private void scoreFillTest(){
		PlayerPrefs.SetString ("Name0", "Imon");
		PlayerPrefs.SetString ("Name1", "Megan");
		PlayerPrefs.SetString ("Name2", "Ivan");
		PlayerPrefs.SetInt ("HighScoreCL10", 123);
		PlayerPrefs.SetInt ("HighScoreCL11", 111);
		PlayerPrefs.SetInt ("HighScoreCL12", 10);
		PlayerPrefs.SetString ("HighscoreNameCL10", "Imon");
		PlayerPrefs.SetString ("HighscoreNameCL11", "Megan");
		PlayerPrefs.SetString ("HighscoreNameCL12", "Ivan");

	}
	public void ScorePress () {
		//scoreFillTest ();
		string[,] names = gm.GetComponent<PlayerSave>().ReturnNames();
		int[,] scores = gm.GetComponent<PlayerSave>().ReturnScores();
		scoreMenu.enabled = true;
		score0.text = "";
		for (int level = 0; level < 4; level++) {
			for (int rank = 0; rank < 3; rank++) {
				if (level == 0) {
					score0.text = score0.text.ToString() + names [level, rank] + "\n" + scores [level, rank] + "\n";
					Debug.Log(scores[level,rank].ToString());
					Debug.Log(names[level,rank].ToString());
				}
				else if(level == 1) {
					score1.text = names [level, rank] + "\n" + scores [level, rank] + "\n";
				}
				else if(level == 2) {
					score2.text = names [level, rank] + "\n" + scores [level, rank] + "\n";
				}
				else if(level == 3) {
					score3.text = names [level, rank] + "\n" + scores [level, rank] + "\n";
				}
			}
		}
	}

}
