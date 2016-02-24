using UnityEngine;
using System.Collections;

public class EnemySeek : MonoBehaviour {

	public Transform enemyBody;
	void Awake(){
		enemyBody = gameObject.transform.parent;
//		targetTransform = GameObject.Find ("Player").GetComponent<Transform> ();
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.CompareTag ("Player")) {
//			Debug.Log ("Within Range.");
			enemyBody.transform.position = Vector3.MoveTowards(enemyBody.transform.position, other.transform.position, Time.deltaTime*2f);
		}
	}
}
