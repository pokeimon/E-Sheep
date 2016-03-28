using UnityEngine;
using System.Collections;

public class shootWithinRange : MonoBehaviour {
	public float playerRange;
	public GameObject bone;
	public PlayerManager player;
	public Transform firePoint;
	public float waitBTWShoot;
	private float shotCounter;
	private ObjectPooler objectPooler;

	void Awake () {
		player = FindObjectOfType<PlayerManager> ();
		shotCounter = waitBTWShoot;
		objectPooler = GameObject.Find("SkeletonBoneObjectPool").GetComponent<ObjectPooler>();
	}

	void Update () {
		//draws line of range for debugging
		Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y,transform.position.z),new Vector3(transform.position.x + playerRange, transform.position.y,transform.position.z));
		shotCounter -= Time.deltaTime;
		//checks to see if player is on the right side to shoot it
		if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange && shotCounter < 0){

			//Instantiate (bone, firePoint.position, firePoint.rotation);
			GameObject obj = objectPooler.getPooledObject();
			obj.SetActive(true);
			if (obj != null) {			
				obj.transform.position = firePoint.position;
				obj.transform.rotation = transform.rotation;
				obj.transform.localScale = transform.localScale * 1f;
				obj.SetActive(true);
			}

			shotCounter = waitBTWShoot; //reseting shotcounter
		}
			//checks to see if player is on the left side to shoot it
		if (transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange && shotCounter < 0){
				
			//Instantiate (bone, firePoint.position, firePoint.rotation);

			GameObject obj = objectPooler.getPooledObject();
			obj.SetActive(true);
			if (obj != null){			
			obj.transform.position = firePoint.position;
				obj.transform.rotation = transform.rotation;
				obj.transform.localScale = transform.localScale * 1.25f;
				obj.SetActive(true);
			}
	
			shotCounter = waitBTWShoot;
				}
		}
}
