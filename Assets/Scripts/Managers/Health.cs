using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int maxHP;
	public int playerStartHP = 2; //player starts at 2 hp
	public int currentHP; //public so it can be seen for testing
	private int damage;
	private Animator animator;

	public float maxMeleeInvuln = 0.4f; //prevents same melee from hitting twice
	public float maxBulletInvuln = 0f; //disabled on default
	public float currentMeleeInvuln = 0f;
	public float currentBulletInvuln = 0f;
	public GameObject deathCanvas; //temp to get deathmenu to work

	void OnEnable () {
		if (this.tag == "Player") {
			currentHP = playerStartHP; 
			animator = GetComponent<Animator> ();
			animator.SetInteger("EquippedItem",1);
		} 
		else { //enemies start at max HP
			currentHP = maxHP;
		}
	}
	
	public void EnergyPickUp(int energy){
		int energyState;

		if (this.tag == "Player") {
			currentHP += energy;
			if(currentHP > maxHP){
				currentHP = maxHP;
			}
			energyState = currentHP -1;
			if (energyState > 1){ //temp until new animations for 3-4 energy
				energyState = 1;
			}
			animator.SetInteger("EquippedItem",energyState);
		} 
	}

	void OnCollisionEnter2D(Collision2D target) { 
		if (this.tag == "Enemy") { 
			if ((target.gameObject.tag == "PlayerBullet") && (currentBulletInvuln >= maxBulletInvuln)) {
				PlayerBullet bullet = target.gameObject.GetComponent<PlayerBullet>();
				damage = bullet.damage; //get damage amount from Bullet
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
				DeathMenu menu = (DeathMenu) deathCanvas.GetComponent("DeathMenu");
				menu.playerDeath();
				gameObject.SetActive (false);
			}
		}
		else if (this.tag == "Enemy") {
			if ((target.gameObject.tag == "PlayerSword") && (currentMeleeInvuln >= maxMeleeInvuln)) {
				PlayerSword sword = target.gameObject.transform.parent.gameObject.GetComponent<PlayerSword>();
				damage = sword.damage; //get damage amount from sword
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
