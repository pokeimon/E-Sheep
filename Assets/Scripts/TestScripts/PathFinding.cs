using UnityEngine;
using System.Collections;

//Attach to the monster
//Generate eight trigger colliders that expand at a constant/random rate

public class PathFinding : MonoBehaviour {

	public GameObject[] radialObjects;
	public GameObject radialPrefab;

	int radialCount;
	float angleIncrements;
	float angleChangeBy;
	float radialLength;
	float radialExtensionLimit;
	public float scanDuration;
	public float movementDuration;

	Rigidbody2D myrigidbody;
	float yMovement;
	float xMovement;

	public Collider2D[] radialColliders;

	int layerToCollideWith;
	int directionToGo;

	// Use this for initialization
	void Start () {
		radialCount = 8;
		radialObjects = new GameObject[radialCount];
		angleIncrements = 0;
		angleChangeBy = 45;
		radialLength = 0f;
		radialExtensionLimit = 10f;//how far the colliders extend
		scanDuration = .3f;
		movementDuration = scanDuration;

		myrigidbody = GetComponent<Rigidbody2D> ();

		radialColliders = new Collider2D[radialCount];

		layerToCollideWith = 8;//corresponds to solid layer

		//creates the extending colliders
		for (int i = 0; i < radialCount; i++) {
			radialObjects [i] = (GameObject)Instantiate (radialPrefab);
			radialObjects [i].transform.localPosition = new Vector3 (
				this.transform.position.x,
				this.transform.position.y,
				this.transform.position.z
			);
			radialObjects [i].transform.SetParent (transform);
			radialColliders [i] = radialObjects [i].GetComponent<Collider2D> ();
		}

		//reorients the extending colliders
		for (int i = 0; i < radialCount; i++) {
			radialObjects [i].transform.localScale = new Vector3 (radialLength, 1f, 1);
			radialObjects [i].transform.Rotate (0f, 0f, angleIncrements);
			angleIncrements = angleIncrements + angleChangeBy;
		}
		StartCoroutine(ExpandRadial());
		StartCoroutine (Navigate());
						
	}
		
	IEnumerator ExpandRadial(){
		while (true) {
			yield return new WaitForSeconds (scanDuration);
			radialLength = radialLength + 1f;
			//resets collider length
			if (radialLength > radialExtensionLimit) {
				radialLength = .1f;
			}
			//expands collider
			for (int i = 0; i < radialCount; i++) {
				radialObjects [i].transform.localScale = new Vector3 (radialLength, .1f, 1);
			}


			
		}

	}

	//Moves the object based on the available collider directions
	IEnumerator Navigate(){
//		bool collidersArePresent = false;
//		for (int i = 0; i < radialCount; i++) {
//			if (radialColliders [i].enabled) {
//				collidersArePresent = true;
//			}
//		}
//		if (!collidersArePresent) {//still doesn't catch
//			Stop ();
//		}

//		while(collidersArePresent){	
		while(true){
			yield return new WaitForSeconds (movementDuration);
			switch (Random.Range (0, 8)) {
			case 0://East
				if (radialColliders [0].enabled) {
					Move (1f, 0f);
//					Move(radialColliders[0].transform.localScale.x, radialColliders[0].transform.localScale.y);
				}
				break;
			case 1://Northeast
				if (radialColliders [1].enabled) {
					Move (1f, 1f);
//					Move(radialColliders[1].transform.localScale.x, radialColliders[1].transform.localScale.y);
				}
				break;
			case 2://North
				if (radialColliders [2].enabled) {
					Move (0f, 1f);
//					Move(radialColliders[2].transform.localScale.x, radialColliders[2].transform.localScale.y);
				}
				break;
			case 3://Northwest
				if (radialColliders [3].enabled) {
					Move (-1f, 1f);
//					Move(-radialColliders[3].transform.localScale.x, radialColliders[3].transform.localScale.y);
				}
				break;
			case 4://West
				if (radialColliders [4].enabled) {
					Move (-1f, 0f);
//					Move(-radialColliders[4].transform.localScale.x, radialColliders[4].transform.localScale.y);
				}
				break;
			case 5://Southwest
				if (radialColliders [5].enabled) {
					Move (-1f, -1f);
//					Move(-radialColliders[5].transform.localScale.x, -radialColliders[5].transform.localScale.y);
				}
				break;
			case 6://South
				if (radialColliders [6].enabled) {
					Move (0f, -1f);
//					Move(radialColliders[6].transform.localScale.x, -radialColliders[6].transform.localScale.y);
				}
				break;
			case 7://Southeast
				if (radialColliders [7].enabled) {
					Move (1f, -1f);
//					Move(radialColliders[7].transform.localScale.x, -radialColliders[7].transform.localScale.y);
				}
				break;
			default://Stop
				Stop();
				break;
			}
		}
	}


	void Move(float xMove, float yMove){
		
		myrigidbody.velocity = new Vector2 (xMove, yMove);
	}

	void Stop(){
		myrigidbody.velocity = new Vector2 (0f,0f);
	}
		
}
