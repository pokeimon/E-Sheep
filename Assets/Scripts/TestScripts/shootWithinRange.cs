using UnityEngine;
using System.Collections;

public class shootWithinRange : MonoBehaviour {
	public float playerRange;
	public GameObject bone;
	public PlayerManager player;
	public Transform firePoint;
	public float waitBTWShoot;
	private float shotCounter;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerManager> ();
		shotCounter = waitBTWShoot;
	}
	
	// Update is called once per frame
	void Update () {
		//draws line of range for debugging
		Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y,transform.position.z),new Vector3(transform.position.x + playerRange, transform.position.y,transform.position.z));
		shotCounter -= Time.deltaTime;
		//checks to see if player is on the right side to shoot it
		if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange && shotCounter < 0)
		{

				Instantiate (bone, firePoint.position, firePoint.rotation);
			shotCounter = waitBTWShoot; //reseting shotcounter
		}
			//checks to see if player is on the left side to shoot it
		if (transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange && shotCounter < 0)
			{
				
					Instantiate (bone, firePoint.position, firePoint.rotation);
			shotCounter = waitBTWShoot;
				}
		}
}
