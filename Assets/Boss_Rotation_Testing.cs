using UnityEngine;
using System.Collections;

public class Boss_Rotation_Testing : MonoBehaviour {

	//Objects in Scene
	public Transform player;
	public GameObject tongueRange;
	public GameObject theTongue;

	public float headAngle;
	public Transform bossHead;

	private Animator animator;
	// Use this for initialization
	void Start () {
		bossHead.eulerAngles = new Vector3 (0,0,0);
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		//This is to check if the player is within the circle collider
		//Using this method to clean up the way the boss head interaction looks in game 
		if (tongueRange.GetComponent<RangeAngle> ().fire) {
			if (theTongue.GetComponent<FrogTongue> ().autostart) {
				animator.SetBool ("bossFireReady", true);
			} else {
				bossHead.eulerAngles = new Vector3 (0, 0, headAngle + 180);
				headAngle = tongueRange.GetComponent<RangeAngle> ().shotAngle;
				animator.SetBool ("bossFireReady", false);
			}
		} else {//outside circle collider, boss head doesn't move, mouth is closed
			animator.SetBool ("bossFireReady", false);
			bossHead.eulerAngles = new Vector3 (0,0,0);
		}
	}

}

