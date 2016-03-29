using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharSelect : PlayerSave {
	//private Component saveScript = GameObject.Find("GM").GetComponent<PlayerSave>();
	public Button newGame0;
	public Button newGame1;
	public Button newGame2;
	//public Button save;
	//public Button delete;
	public Button enter;
	public Canvas enterCharName;
	//public Canvas char0;
	//public Canvas char1;
	//public Canvas char2;
	public InputField name;


	// Use this for initialization
	void Start () {
		newGame0 = newGame0.GetComponent<Button> ();
		newGame1 = newGame1.GetComponent<Button> ();
		newGame2 = newGame2.GetComponent<Button> ();
		//save = save.GetComponent<Button> ();
		//delete = delete.GetComponent<Button> ();
		enter = enter.GetComponent<Button> ();

		//char0 = char0.GetComponent<Canvas> ();
		//char1 = char1.GetComponent<Canvas> ();
		//char2 = char2.GetComponent<Canvas> ();
		enterCharName = enterCharName.GetComponent<Canvas> ();
		name = name.GetComponent<InputField> ();

		enterCharName.enabled = false;

		/*
		//Char 0
		if (IsNewGame (0)) {
			Char0.enabled = false;
		} else
			NG0.enabled = false;

		//Char 1
		if (IsNewGame (1)) {
			Char1.enabled = false;
		} else
			NG1.enabled = false;

		//Char 2
		if (IsNewGame (2)) {
			Char2.enabled = false;
		} else
			NG2.enabled = false;

		*/
	}

	private bool IsNewGame (int select) {
		if (PlayerPrefs.GetString ("Name" + select) == null) {
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
		Application.LoadLevel (1);
	}



}
