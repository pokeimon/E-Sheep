using UnityEngine;
using System.Collections;

public class BossHealthMananger : MonoBehaviour {
	public GameObject deathEffect;
	private Health health;
	private int HP;
	private int maxHP;
	private Rigidbody2D rb;
	public GameObject bossPrefab;
	public float minsize; //smallest size
	// Use this for initialization
	void Awake () {
		health = GetComponent<Health> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	// Update is called once per frame
	void Update () {
		HP = health.currentHP;
		maxHP = health.maxHP;
	if ( HP<=5) {
			rb = GetComponent<Rigidbody2D> ();
			Instantiate(deathEffect, transform.position, transform.rotation);
			if(transform.localScale.y > minsize){
			GameObject clone1 = Instantiate(bossPrefab, new Vector3 (transform.position.x + 1.5f, 
				               transform.position.y, transform.position.z),transform.rotation)as GameObject;
				rb = clone1.GetComponent<Rigidbody2D> ();
				rb.isKinematic= false;
			GameObject clone2 = Instantiate(bossPrefab, new Vector3 (transform.position.x - 1.5f, 
				                transform.position.y, transform.position.z),transform.rotation)as GameObject;
				rb = clone2.GetComponent<Rigidbody2D> ();
				rb.isKinematic= false;
				clone1.transform.localScale = new Vector3(transform.localScale.x *.75f, transform.localScale.y *.5f, transform.localScale.z);
				clone1.GetComponent<BossHealthMananger>().HP =20;
				clone2.transform.localScale = new Vector3(transform.localScale.x *.75f, transform.localScale.y *.5f, transform.localScale.z);
				clone2.GetComponent<BossHealthMananger>().HP=20;
			}
				Destroy(gameObject);
			}
		}


	}

