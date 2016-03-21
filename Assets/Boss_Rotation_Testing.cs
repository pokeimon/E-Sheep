using UnityEngine;
using System.Collections;

public class Boss_Rotation_Testing : MonoBehaviour {

	public Transform player;
	public Transform bossHead;
	public Collider2D c;
	public float headAngle;


	// Use this for initialization
	void Start () {
		c = gameObject.GetComponent<Collider2D>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		headAngle = 57.296f * Mathf.Atan2((player.position.y - bossHead.position.y), (player.position.x - bossHead.position.x));

	}

	void OnTriggerStay2D(Collider2D col){
		if(col.gameObject.tag.Equals ("Player")){
			bossHead.eulerAngles = new Vector3 (0, 0, headAngle + 145);
		}
	}
}

