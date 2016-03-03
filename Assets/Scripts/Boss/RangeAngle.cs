using UnityEngine;
using System.Collections;


public class RangeAngle : MonoBehaviour {

	public Transform player;
	public Transform playerOnEnter;
	public Transform tongue;
	public Collider2D c;
	public GameObject Boss;
	public float shotAngle;
	public bool fire = false;

	// Use this for initialization
	void Start () {
		c = gameObject.GetComponent<Collider2D>();
		//c.enabled = true;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(fire == false)
			c.enabled = true;
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag.Equals ("Player")){
			Debug.Log ("Player entered range.");
			shotAngle = 57.296f * Mathf.Atan2((player.position.y - tongue.position.y), (player.position.x - tongue.position.x));
			playerOnEnter.position = new Vector2 (player.position.x, player.position.y);
			c.enabled = false;
			fire = true;
		}
	}
		
}
