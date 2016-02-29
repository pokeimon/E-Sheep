using UnityEngine;
using System.Collections;


public class RangeAngle : MonoBehaviour {

	public Transform player;
	public Transform tongue;
	public float shotAngle;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D col){
		if(col.gameObject.tag.Equals ("Player")){
			Debug.Log ("Player entered range.");
			shotAngle = Mathf.Atan2((player.position.y - tongue.position.y), (player.position.x - tongue.position.x));
		}
	}
}
