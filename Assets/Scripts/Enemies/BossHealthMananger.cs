using UnityEngine;
using System.Collections;

public class BossHealthMananger : MonoBehaviour {
	public int enemyHealth;
	public GameObject deathEffect;
	public GameObject bossPrefab;
	public float minsize; //smallest size
	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
	if (enemyHealth <= 0) {
			Instantiate(deathEffect, transform.position, transform.rotation);
			if(transform.localScale.y > minsize){
			GameObject clone1 = Instantiate(bossPrefab, new Vector3 (transform.position.x +.05f, 
				               transform.position.y, transform.position.z),transform.rotation)as GameObject;
			GameObject clone2 = Instantiate(bossPrefab, new Vector3 (transform.position.x -.05f, 
				                transform.position.y, transform.position.z),transform.rotation)as GameObject;
				clone1.transform.localScale = new Vector3(transform.localScale.x *.5f, transform.localScale.y *.5f, transform.localScale.z);
				clone1.GetComponent<BossHealthMananger>().enemyHealth =10;
				clone2.transform.localScale = new Vector3(transform.localScale.x *.5f, transform.localScale.y *.5f, transform.localScale.z);
				clone2.GetComponent<BossHealthMananger>().enemyHealth =10;
			}
				Destroy(gameObject);
			}
		}
	public void giveDamage(int damageToGive){
		enemyHealth -= damageToGive;
	}


	}

