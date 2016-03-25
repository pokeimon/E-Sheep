using UnityEngine;
using System.Collections;

public class Boss_Rotation_Testing : MonoBehaviour {

	public Transform player;
	public Transform bossHead;
	public float headAngle;
	public GameObject tongueRange;
	public GameObject theTongue;


	private Animator animator;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		//headAngle = 57.296f * Mathf.Atan2((player.position.y - bossHead.position.y), (player.position.x - bossHead.position.x));
		headAngle = tongueRange.GetComponent<RangeAngle>().shotAngle;
		bossHead.eulerAngles = new Vector3 (0,0, headAngle + 145);

		if (theTongue.GetComponent<FrogTongue> ().autostart) {
			animator.SetBool("bossFireReady", true);
		} else {
			animator.SetBool("bossFireReady", false);
		}

	}

}

