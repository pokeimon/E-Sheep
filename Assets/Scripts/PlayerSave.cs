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
		PlayerPrefs.SetInt ("Level" + saveNum, null);
		PlayerPrefs.SetInt ("Score" + saveNum, null);
		PlayerPrefs.SetInt ("PersonalBestCL1" + saveNum, null);
		PlayerPrefs.SetInt ("PersonalBestCL2" + saveNum, null);
		PlayerPrefs.SetInt ("PersonalBestHL1" + saveNum, null);
	}

	public void EndLevel (int level) {
		int playerNum = PlayerPrefs.GetInt ("SelectedPlayer");
		string playerPref = ChooseLevel ("PersonalBest", level);
		int score = PlayerPrefs.GetInt ("Score");
		if (score > PlayerPrefs.GetInt (playerPref)) {
			PlayerPrefs.SetInt (playerPref, score);
		}
		//Check highscore stuff here too 
	}

	private string ChooseLevel (string saveNum, int level){
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
			break;
		}

		return sLevel;
	}


}
