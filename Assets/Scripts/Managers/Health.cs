using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int maxHP;
	public int playerStartHP = 2; //player starts at 2 hp?
	public int currentHP; //publics so it can be seen for testing
	private int damage;
	public float maxMeleeInvuln = 0.4f; //prevents same melee from hitting twice
	public float maxBulletInvuln = 0f; //disabled on default
	public float currentMeleeInvuln = 0f;
	public float currentBulletInvuln = 0f;
	
	void OnEnable () {
		if (this.tag == "Player") {
			currentHP = playerStartHP; 
		} 
		else { //enemies start at max HP
			currentHP = maxHP;
		}
	}
	
	void OnCollisionEnter2D(Collision2D target) { 
		if (this.tag == "Enemy") { 
			if ((target.gameObject.tag == "PlayerBullet") && (currentBulletInvuln >= maxBulletInvuln)) {
				//damage = target.PlayerBullet.damage; //variable bullet damage
				damage = 1; //temp damage amount
				currentHP -= damage;
			}
			if (currentHP < 1) {
				gameObject.SetActive (false);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (this.tag == "Player") {
			if((target.gameObject.tag == "Enemy") && (currentMeleeInvuln >= maxMeleeInvuln)){
				currentHP -= 1; //player always takes 1 damage.
				currentMeleeInvuln = 0f; //make player unable to take damage for a time;
			}
			if (currentHP < 1) {
				gameObject.SetActive (false);
			}
		}
		else if (this.tag == "Enemy") {
			if ((target.gameObject.tag == "PlayerSword") && (currentMeleeInvuln >= maxMeleeInvuln)) {
				//damage = target.PlayerSword.damage; //variable bullet damage
				damage = 5; //temp damage amount
				currentHP -= damage;
				currentMeleeInvuln = 0f;
			}
			if (currentHP < 1) {
				gameObject.SetActive (false);
			}
		}
	}


	void FixedUpdate() {
		if ((maxBulletInvuln > 0f) && (currentBulletInvuln < maxBulletInvuln)) {
			currentBulletInvuln+= Time.deltaTime;
		}
		if ((maxMeleeInvuln > 0f) && (currentMeleeInvuln < maxMeleeInvuln)) {
			currentMeleeInvuln+= Time.deltaTime;
		}
	}
}
