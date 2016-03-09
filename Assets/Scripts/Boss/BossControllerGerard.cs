using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossControllerGerard : MonoBehaviour {

	public GameObject someEnemy;
	public List<GameObject> list;
	public List<Color> colorSelection;

	public int mobLimit;
	public int waveLimit;

	public bool fire; //added by steven
	bool waitForWipe;
	int wave;
	int activeMonsterCount;

	// Use this for initialization
	void Awake () {
//		mobLimit = 0;
		waitForWipe = true;
		wave = 0;
		activeMonsterCount = 0;

		colorSelection.Add (Color.green);
		colorSelection.Add (Color.red);
		colorSelection.Add (Color.yellow);
		colorSelection.Add (Color.blue);
		colorSelection.Add (Color.cyan);
		colorSelection.Add (Color.magenta);
		fire = false;
	}
	
	// Update is called once per frame
	void Update () {
		activeMonsterCount = list.Count;
		for (int i = 0; i < list.Count; i++) {
			if (!list [i].gameObject.activeSelf) {//temp becomes a measure of how many monsters are still active, if zero, then 
				activeMonsterCount--;	
			}
		}
		if (activeMonsterCount == 0 && wave<waveLimit) {//this is if there are either zero objects in the list, or if they have been deactivated. Also, limits wave
			if(wave > 0){
				fire = true; //added by steven
			}
			Debug.Log ("Spawn.");
			for (int i = 0; i < mobLimit; i++) {
				list.Add ((GameObject)Instantiate (someEnemy, transform.position, transform.rotation));
				//access the recently added item
				list [list.Count-1].GetComponentInChildren<SpriteRenderer>().color = colorSelection[Random.Range (0, colorSelection.Count)];
				list [list.Count - 1].transform.FindChild ("Range Collider").GetComponent<Collider2D> ().transform.localScale = new Vector2 (2f, 2f);
			}
			wave++;
		}


	}


}
