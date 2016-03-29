using UnityEngine;
using System.Collections;

public class PlayerSave : MonoBehaviour {

	//SelectedPlayer

	//int0
	//int1
	//int2

	//"Name"+saveNum
	//"Level"+saveNum
	//"Score"+saveNum

	//"PersonalBestCL1"+saveNum
	//"PersonalBestCL2"+saveNum
	//"PersonalBestHL1"+saveNum

	//"HighScoreCL1"+rank
	//"HighScoreCL2"+rank
	//"HighScoreHL1"+rank

	//"HighscoreNameCL1"+rank
	//"HighscoreNameCL2"+rank
	//"HighscoreNameHL1"+rank

	//Level 0 = CL1
	//Level 1 = CL
	//Level 2 = HL1

	/// <summary>
	/// Runs when loaded to verify that there is a selected player
	/// If missing sets to default load of 0
	/// </summary>
	void Start(){
		int selected = PlayerPrefs.GetInt ("SelectedPlayer");
		if (selected != 0 || selected != 1 || selected != 2) {
			PlayerPrefs.SetInt ("SelectedPlayer", 0);
		}
	}

	public void NewSave(int saveNum, string name){
		PlayerPrefs.SetString ("Name"+saveNum, name);
		PlayerPrefs.SetInt ("Level"+saveNum, 0);
		PlayerPrefs.SetInt ("Score"+saveNum, 0);
		PlayerPrefs.SetInt ("PersonalBestCL1" + saveNum, 0);
		PlayerPrefs.SetInt ("PersonalBestCL2" + saveNum, 0);
		PlayerPrefs.SetInt ("PersonalBestHL1" + saveNum, 0);
	}
		
	public void EraseSave(int saveNum){
		PlayerPrefs.SetString ("Name" + saveNum, null);
		PlayerPrefs.SetInt ("Level" + saveNum, 0);
		PlayerPrefs.SetInt ("Score" + saveNum, 0);
		PlayerPrefs.SetInt ("PersonalBestCL1" + saveNum, 0);
		PlayerPrefs.SetInt ("PersonalBestCL2" + saveNum, 0);
		PlayerPrefs.SetInt ("PersonalBestHL1" + saveNum, 0);
		Debug.Log ("erase" + saveNum);
	}

	public void UpdateSave (int level) {
		int saveNum = PlayerPrefs.GetInt ("SelectedPlayer");
		string personalBest = ChooseLevel ("PersonalBest", level) + saveNum;
		string highScore = ChooseLevel ("HighScore", level); 
		int score = PlayerPrefs.GetInt ("Score");
		if (score > PlayerPrefs.GetInt (personalBest)) {
			PlayerPrefs.SetInt (personalBest, score);
		}
		//if (score > PlayerPrefs.GetInt (highScore + 2)) {
		HighScoreAdd(PlayerPrefs.GetString ("Name" + saveNum), score, level);
		//}
		if (PlayerPrefs.GetInt ("Level" + saveNum) < level) {
			PlayerPrefs.SetInt ("Level" + saveNum, level);
		}
	}

	private void HighScoreAdd(string name, int score, int level){
		string highScore = ChooseLevel ("HighScore", level);
		for (int i = 2; i <= 0; i--) {
			if (score > PlayerPrefs.GetInt (highScore + i)) {
				if (i != 2) {
					int num = i + 1;
					PlayerPrefs.SetInt (highScore + num, PlayerPrefs.GetInt (highScore + i));
					PlayerPrefs.SetString (highScore + "Name" + num, PlayerPrefs.GetString (highScore + "Name" + i));
				}
				PlayerPrefs.SetInt (highScore + i, score);
				PlayerPrefs.SetString (highScore + "Name" + i, name);
			} else
				break;
		}
	}
	/// <summary>
	/// Returns the scores.
	/// [Rank, Level]
	/// </summary>
	/// <returns>The scores.</returns>
	public int[,] ReturnScores (){
		int[,] scores = new int[3, 4];
		string temp;
		for (int i = 0; i < 4; i++) {
			for (int rank = 0; rank < 3; rank++){
				if (rank != 3) {
					temp = ChooseLevel ("HighScore", i);
					scores [rank, i] = PlayerPrefs.GetInt (temp + rank); 
				} 
				else {
					string personalBest = ChooseLevel ("PersonalBest", i) + PlayerPrefs.GetInt("SelectedPlayer");	
					scores [rank, i] = PlayerPrefs.GetInt (personalBest);
				}	
			}
		}
		return scores;
	}

	/// <summary>
	/// Returns the names.
	/// [Ramk, level]
	/// </summary>
	/// <returns>The names.</returns>
	public string[,] ReturnNames (){
		string[,] names = new string[3, 4];
		string temp;
		for (int i = 0; i < 4; i++) {
			for (int rank = 0; rank < 3; rank++){
				if (rank != 3) {
					temp = ChooseLevel ("HighScoreName", i);
					names [rank, i] = PlayerPrefs.GetString (temp + rank); 
				} 
				else {
					names [rank, i] = "Personal Best";
				}
			}
		}
		return names;
	}

	private string ChooseLevel (string sPref, int level){
		string sLevel;
		switch (level) {
		case 0:
			sLevel = "CL1";
			break;
		case 1:
			sLevel = "CL2";
			break;
		case 2:
			sLevel = "HL1";
			break;
		default:
			sLevel = null;
			break;
		}
		return (sPref + sLevel);
	}

		
}
