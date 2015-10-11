using UnityEngine;
using System.Collections;

public class Flan : MonoBehaviour {

	public int maxHP = 5;
	private int currentHP;

	void OnEnable (){
		currentHP = maxHP;
	}

	void OnCollisionEnter2D(Collision2D target) {
		if (target.gameObject.tag == "Bullet") {
			currentHP -= 1;
		}
		if (currentHP < 1) {
			gameObject.SetActive(false);
		}
	}
}
