using UnityEngine;
using System.Collections;

public class SkeletonController : AbstractEnemy {
	//public Transform firePoint;
	public GameObject deathEffect;
	private Health health;
	public int HP;
	public int maxHp;
//	void awake(){
//		health = GetComponent<Health> ();
	//}

	// Use this for initialization
	void Start () {
		health = GetComponent<Health> ();
	}
	
	// Update is called once per frame
	void Update () {
		HP = health.currentHP;
		maxHp = health.maxHP;
	}
}
