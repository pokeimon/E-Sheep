using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharSelect : PlayerSave {
	//private Component saveScript = GameObject.Find("GM").GetComponent<PlayerSave>();
	public Button newGameB0;
	public Button newGameB1;
	public Button newGameB2;

	public Canvas newGame0;
	public Canvas newGame1;
	public Canvas newGame2;


	public Button cont;
	public Button delete;
	public Button enter;
	public Canvas enterCharName;
	public Canvas char0;
	public Canvas char1;
	public Canvas char2;
	public InputField name;

	public Text playerName0;
	public Text playerName1;
	public Text playerName2;



	// Use this for initialization
	void Start () {
		newGameB0 = newGameB0.GetComponent<Button> ();
		newGameB1 = newGameB1.GetComponent<Button> ();
		newGameB2 = newGameB2.GetComponent<Button> ();

		newGame0 = newGame0.GetComponent<Canvas> ();
		newGame1 = newGame1.GetComponent<Canvas> ();
		newGame2 = newGame2.GetComponent<Canvas> ();

		cont = cont.GetComponent<Button> ();
		delete = delete.GetComponent<Button> ();
		enter = enter.GetComponent<Button> ();

		char0 = char0.GetComponent<Canvas> ();
		char1 = char1.GetComponent<Canvas> ();
		char2 = char2.GetComponent<Canvas> ();

		enterCharName = enterCharName.GetComponent<Canvas> ();

		name = name.GetComponent<InputField> ();

		enterCharName.enabled = false;

		for(int i = 0; i < 3; i++){
			if (PlayerPrefs.GetInt ("int" + i) != 1) {
				EraseSave (i);
				PlayerPrefs.SetInt ("int" + i, 1);
			}
		}

		//Char 0
		if (IsNewGame (0)) {
			char0.enabled = false;
		} else{
			newGame0.enabled = false;
			playerName0.text = PlayerPrefs.GetString ("Name0");
		}
		//Char 1
		if (IsNewGame (1)) {
			char1.enabled = false;
		} else{
			newGame1.enabled = false;
			playerName1.text = PlayerPrefs.GetString ("Name1");
		}
		//Char 2
		if (IsNewGame (2)) {
			char2.enabled = false;
		} else{
			newGame2.enabled = false;
			playerName2.text = PlayerPrefs.GetString ("Name2");
		}

	}

	private bool IsNewGame (int select) {
		if (string.IsNullOrEmpty( PlayerPrefs.GetString ("Name" + select))) {
			return true;
		} else
			return false;
	}

	public void PressNewGame (int select) {
		enterCharName.enabled = true; //turns on character name canvas

		//enter.enabled = true;
		PlayerPrefs.SetInt ("SelectedPlayer", select);
	}

	public void PressEnter () {
		PlayerPrefs.SetString ("Name" + PlayerPrefs.GetInt ("SelectedPlayer"), name.text);
		Application.LoadLevel (1);
		Debug.Log(PlayerPrefs.GetString("Name" + PlayerPrefs.GetInt ("SelectedPlayer")));
	}

	public void PressContinue (int select) {
		PlayerPrefs.SetInt ("SelectedPlayer", select);
		Application.LoadLevel (1);
	}

	public void PressDelete (int select) {
		EraseSave (select);
		Application.LoadLevel (5);
	}


}
