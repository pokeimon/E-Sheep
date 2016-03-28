using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharSelect : PlayerSave {
	//private Component saveScript = GameObject.Find("GM").GetComponent<PlayerSave>();
	public Button NG0;
	public Button NG1;
	public Button NG2;
	public Button save;
	public Button delete;
	public Button enter;
	public Canvas EnterCharName;
	public Canvas Char0;
	public Canvas Char1;
	public Canvas Char2;
	public InputField name;


	// Use this for initialization
	void Start () {
		NG0 = NG0.GetComponent<Button> ();
		NG1 = NG1.GetComponent<Button> ();
		NG2 = NG2.GetComponent<Button> ();
		save = save.GetComponent<Button> ();
		delete = delete.GetComponent<Button> ();
		enter = enter.GetComponent<Button> ();
		Char0 = Char0.GetComponent<Canvas> ();
		Char1 = Char1.GetComponent<Canvas> ();
		Char2 = Char2.GetComponent<Canvas> ();
		EnterCharName = EnterCharName.GetComponent<Canvas> ();
		name = name.GetComponent<InputField> ();

		EnterCharName.enabled = false;
		save.enabled = false;
		delete.enabled = false;
		enter.enabled = false;
		name.enabled = false;


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
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private bool IsNewGame (int select) {
		if (PlayerPrefs.GetString ("Name" + select) == null) {
			return true;
		} else
			return false;
	}

	private void NewGame (int select) {
		EnterCharName.enabled = true; //turns on character name canvas
//		NewSave (select, name);
		enter.enabled = true;
		PlayerPrefs.SetInt ("SelectedPlayer", select);
	}

	void PressEnter () {
		Application.LoadLevel (1);
	}




}
