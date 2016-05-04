using UnityEngine;
using System.Collections;

public class HorrorLandBoss : MonoBehaviour {
	private ObjectPooler objectPooler;
	private Health health; //may not be needed
	private Rigidbody2D body2d;

	private GameObject sword;
	private GameObject jumpShockWave;
	private GameObject punchShockWave;
	public Transform firingPoint;
	public Transform jumpWavePoint;
	public float jumpHeight = 20f;

	public LayerMask collisionLayer;
	public float collisionRadius = 0.25f;
	public Vector2 bottomPos = Vector2.zero;
	public Color collisionColor = Color.red;

	public float shootDelay = 2f;
	public float meleeDelay = 20f;
	public float jumpDelay = 10f;
	public float punchDelay = 15f;

	public float currentShootDelay = 2f;
	public float currentMeleeDelay = 7f;
	public float currentJumpDelay = 7f;
	public float currentPunchDelay = 7f;

	public bool moveActive = false;
	public bool jumping = false;
	public bool standing = true;

	void Awake(){
		Time.timeScale = 1f;
		objectPooler = GameObject.Find("HorrorBossObjectPool").GetComponent<ObjectPooler>();
		health = GetComponent<Health> ();
		body2d = GetComponent<Rigidbody2D> ();
		sword = transform.GetChild(0).gameObject;
		jumpShockWave = transform.GetChild (1).gameObject;
		punchShockWave = transform.GetChild (2).gameObject;
	}

	void FixedUpdate() {
		if (jumping && currentJumpDelay > 1.15f) { //landing from Jump and Create ShockWave
			if (standing) {
				jumpShockWave.transform.rotation = transform.rotation;
				jumpShockWave.transform.position = jumpWavePoint.position;
				jumpShockWave.SetActive(true);
				jumping = false;
				GameObject.Find ("Main Camera").GetComponent<ShakeCamera> ().DoShake ();
			}
		}
		if (sword.activeSelf || jumpShockWave.activeSelf || punchShockWave.activeSelf || !standing) {
			moveActive = true;
		}
		else {
			moveActive = false;
		}
		if (!moveActive) {
			if (currentShootDelay > shootDelay) { //try shoot
				Shoot ();
				currentShootDelay = 0f;
			}
			if (currentMeleeDelay > meleeDelay) { //try melee
				Melee ();
				currentMeleeDelay = 0f;
			}
			else if (currentJumpDelay > jumpDelay) { //try melee
				Jump ();
				jumping = true;
				currentJumpDelay = 0f;
			}
			else if (currentPunchDelay > punchDelay) { //try melee
				Punch ();
				currentPunchDelay = 0f;
			}
		}

		standing = Physics2D.OverlapCircle (bottomPos, collisionRadius, collisionLayer);
		currentPunchDelay += Time.deltaTime;	
		currentJumpDelay += Time.deltaTime;	
		currentShootDelay += Time.deltaTime;
		currentMeleeDelay += Time.deltaTime;
	
	}

	void Shoot(){
		GameObject obj = objectPooler.getPooledObject();

		if (obj != null) {			
			obj.transform.position = firingPoint.position;
			obj.transform.rotation = transform.rotation;
			obj.transform.localScale = transform.localScale * .06f;
			obj.SetActive (true);
		}
	}

	void Melee(){
		sword.SetActive(true); //swing sword and reset for delay
	}

	void Jump(){
		body2d.velocity = new Vector2 (0f, jumpHeight); 
	}

	void Punch(){
		punchShockWave.transform.rotation = transform.rotation;
		punchShockWave.transform.position = firingPoint.position;
		punchShockWave.SetActive(true);
	}

	void OnDrawGizmos(){
		Gizmos.color = collisionColor;

		var pos = bottomPos;
		pos.x += transform.position.x;
		pos.y += transform.position.y;

		Gizmos.DrawWireSphere (pos, collisionRadius);
	}

	void OnDisable(){
		Debug.Log ("I....AM.......SAGIJIM!!!!!!!!!!!!!!");
		Time.timeScale = 0.5f;
		GameObject.Find ("Main Camera").GetComponent<ShakeCamera> ().DoShake ();
	}
}
