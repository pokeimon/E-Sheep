using UnityEngine;
using System.Collections;

public class PlayerSave : MonoBehaviour {

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

	public void NewSave(int saveNum, string name){
		PlayerPrefs.SetString ("Name"+saveNum, name);
		PlayerPrefs.SetInt ("Level"+saveNum, 0);
		PlayerPrefs.SetInt ("Score"+saveNum, 0);
		PlayerPrefs.SetInt ("PersonalBestCL1" + saveNum, 0);
		PlayerPrefs.SetInt ("PersonalBestCL2" + saveNum, 0);
		PlayerPrefs.SetInt ("PersonalBestHL1" + saveNum, 0);
	}
		
	public void EraseSave(int saveNum){
		PlayerPrefs.SetString ("Name", null);
		PlayerPrefs.SetInt ("Level" + saveNum, 0);
		PlayerPrefs.SetInt ("Score" + saveNum, 0);
		PlayerPrefs.SetInt ("PersonalBestCL1" + saveNum, 0);
		PlayerPrefs.SetInt ("PersonalBestCL2" + saveNum, 0);
		PlayerPrefs.SetInt ("PersonalBestHL1" + saveNum, 0);
	}

	public void UpdateScore (int level) {
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
