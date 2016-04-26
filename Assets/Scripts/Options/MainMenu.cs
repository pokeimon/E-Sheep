using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public Canvas exitMenu;
	public Canvas creditMenu;
	public Canvas scoreMenu;
	public Canvas playMenu;

	public Button startText;
	public Button exitText;
	public Button mainMenuText0;
	public Button mainMenuText1;
	public Button newGameText;
	public Button scoreText;
	public Button playText;

	public GameObject gm;

	public Text score0;
	public Text score1;
	public Text score2;


	// Use this for initialization
	void Start () {
		gm = GameObject.Find("GM");

		exitMenu = exitMenu.GetComponent<Canvas> ();
		creditMenu = creditMenu.GetComponent<Canvas> ();
		scoreMenu = scoreMenu.GetComponent<Canvas> ();
		playMenu = playMenu.GetComponent<Canvas> ();

		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		mainMenuText0 = mainMenuText0.GetComponent<Button> ();
		mainMenuText1 = mainMenuText1.GetComponent<Button> ();
		newGameText = newGameText.GetComponent<Button> ();
		scoreText = scoreText.GetComponent<Button> ();
		playText = playText.GetComponent<Button> ();

		exitMenu.enabled = false; //exit menu is disabled
		creditMenu.enabled = false; //credit menu is disabled
		scoreMenu.enabled = false; //score menu is disabled
		playMenu.enabled = false; //how to play menu is disabled

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
		mainMenuText0.enabled = true;
		
	}

	public void PlayPress() {
	
		playMenu.enabled = true;
		mainMenuText1.enabled = true;

	}

	
	//go back to main menu
	public void MenuPress() {

		creditMenu.enabled = false;
		playMenu.enabled = false;

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
		PlayerPrefs.SetString ("HighScoreNameCL10", "Imon");
		PlayerPrefs.SetString ("HighScoreNameCL11", "Megan");
		PlayerPrefs.SetString ("HighScoreNameCL12", "Ivan");
		PlayerPrefs.SetInt ("HighScoreCL10", 123);
		PlayerPrefs.SetInt ("HighScoreCL11", 111);
		PlayerPrefs.SetInt ("HighScoreCL12", 10);

		PlayerPrefs.SetInt ("HighScoreCL20", 456);
		PlayerPrefs.SetInt ("HighScoreCL21", 212);
		PlayerPrefs.SetInt ("HighScoreCL22", 111);

		PlayerPrefs.SetInt ("HighScoreHL10", 963);
		PlayerPrefs.SetInt ("HighScoreHL11", 852);
		PlayerPrefs.SetInt ("HighScoreHL12", 741);

		PlayerPrefs.SetInt ("PersonalBestCL10", 5);
		PlayerPrefs.SetInt ("PersonalBestCL11", 5);
		PlayerPrefs.SetInt ("PersonalBestCL12", 5);

		PlayerPrefs.SetInt ("PersonalBestCL20", 3);

		PlayerPrefs.SetInt ("PersonalBestHL10", 1);
	}

	public void ScorePress () {
		//scoreFillTest ();
		string[,] names = gm.GetComponent<PlayerSave>().ReturnNames();
		int[,] scores = gm.GetComponent<PlayerSave>().ReturnScores();
		scoreMenu.enabled = true;
		score0.text = "Candy Land 1" + "\n";
		score1.text = "Candy Land 2" + "\n";
		score2.text = "Horror Land 1" + "\n";
		for (int level = 0; level < 4; level++) {
			for (int rank = 0; rank < 3; rank++) {
				if (level == 0) {
					score0.text += names [rank, level] + "\n\t" + scores [rank, level] + "\n";
					Debug.Log (names [rank, level] + "\n\t" + scores [rank, level] + "\n");
				}
				else if(level == 1) {
					score1.text += names [rank, level] + "\n\t" + scores [rank, level] + "\n";
				}
				else if(level == 2) {
					score2.text += names [rank, level] + "\n\t" + scores [rank, level] + "\n";
				}
				else{
					if(rank==0)
						score0.text += "Personal Best" + "\n\t" + scores [rank, level];
					else if(rank ==1)
						score1.text += "Personal Best" + "\n\t" + scores [rank, level];
					else
						score2.text += "Personal Best" + "\n\t" + scores [rank, level];
				}
			}
		}
	}
}
