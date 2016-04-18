using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossController: MonoBehaviour {

	public GameObject someEnemy;
	public List<GameObject> list;
	public List<Color> colorSelection;

	public int mobLimit;
	public int waveLimit;
	public int k = 0;

	public bool fire = false; //added by steven
	int wave;
	int activeMonsterCount;

	private RangeAngle rangeAngle;
	private FrogTongue frogTongue;

	// Use this for initialization
	void Awake () {
		rangeAngle = GameObject.Find("Range").GetComponent<RangeAngle>();
		frogTongue = GameObject.Find("Tongue").GetComponent<FrogTongue>();
		wave = 0;
		activeMonsterCount = 0;

		colorSelection.Add (Color.green);
		colorSelection.Add (Color.red);
		colorSelection.Add (Color.yellow);
		colorSelection.Add (Color.blue);
		colorSelection.Add (Color.cyan);
		colorSelection.Add (Color.magenta);
	}
	
	// Update is called once per frame
	void Update () {
		activeMonsterCount = list.Count;
		for (int i = 0; i < list.Count; i++) {
			if (!list [i].gameObject.activeSelf) {//temp becomes a measure of how many monsters are still active, if zero, then 
				activeMonsterCount--;	
			}
		}

		Debug.Log (frogTongue.hit);

		if (activeMonsterCount == 0 && wave<=waveLimit && !frogTongue.hit) {//this is if there are either zero objects in the list, or if they have been deactivated. Also, limits wave
			
			if(wave > 0 && k < 1){
				fire = true; //added by steven
				k++;
			}
			if(!fire && wave<waveLimit){
				for (int i = 0; i < mobLimit; i++) {
					list.Add ((GameObject)Instantiate (someEnemy, transform.position, transform.rotation));
					//access the recently added item
					list [list.Count - 1].GetComponentInChildren<SpriteRenderer> ().color = colorSelection [Random.Range (0, colorSelection.Count)];
					list [list.Count - 1].transform.FindChild ("Range Collider").GetComponent<Collider2D> ().transform.localScale = new Vector3 (2f, 2f, 2f);
				}
				wave++;
				k = 0;
			}
		}
	}
}
