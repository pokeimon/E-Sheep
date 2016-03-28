using UnityEngine;
using System.Collections;

public class BossBat : MonoBehaviour {
	private GameObject objPool;
	private Health health;

	void Awake () {
		objPool = GameObject.Find("HorrorBossObjectPool");
		this.transform.SetParent(objPool.transform);
		health = this.transform.GetChild(1).gameObject.GetComponent<Health>() ;
	}

	void OnEnable() {
		health.currentHP = health.maxHP;
	}
	

}
