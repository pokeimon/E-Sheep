using UnityEngine;
using System.Collections;


public class RangeAngle : MonoBehaviour {

	public Transform player;
	public Transform playerOnEnter;
	public Transform tongue;
	public Collider2D c;
	public float shotAngle = 0;
	public float tempAngle;
	public bool fire = false;

	private FrogTongue frogTongue;

	// Use this for initialization
	void Start () {
		frogTongue = GetComponentInParent<FrogTongue>();
		c = gameObject.GetComponent<Collider2D>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (fire == false) {
			c.enabled = true;
		} else {
			tempAngle = 57.296f * Mathf.Atan2 ((player.position.y - tongue.position.y), (player.position.x - tongue.position.x));
			if ((tempAngle < -160 && tempAngle > -180) || (tempAngle > 160 && tempAngle < 180)) {
				shotAngle = tempAngle;
			}
			//shotAngle = 90 + 57.296f * Mathf.Atan2 ((player.position.y - tongue.position.y), (player.position.x - tongue.position.x));
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if(col.gameObject.tag.Equals ("Player")){
			fire = true;
			tongue.eulerAngles = new Vector3 (0, 0, shotAngle+90);
			playerOnEnter.position = new Vector2 (player.position.x, player.position.y);
			if (frogTongue.autostart == true) {
				c.enabled = false;
			}
		}
	}
}
