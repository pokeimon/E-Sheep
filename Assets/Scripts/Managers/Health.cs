using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int maxHP;
	public int playerStartHP = 2; //player starts at 2 hp?
	public int currentHP; //publics so it can be seen for testing
	private int damage;
	public float maxInvuln = 0f; //disabled on default
	private float currentInvuln = 0f;

	
	void OnEnable () {
		if (this.tag == "Player") {
			currentHP = playerStartHP; 
		} 
		else { //enemies start at max HP
			currentHP = maxHP;
		}
	}
	
	void OnCollisionEnter2D(Collision2D target) {
		if (this.tag == "Player") {
			if((target.gameObject.tag == "EnemyBullet") && (currentInvuln >= maxInvuln)){
				currentHP -= 1; //player always takes 1 damage.
				currentInvuln = 0; //make player unable to take damage for a time;
			}
			if (currentHP < 1) {
				//player death stuff
			}
		} 
		else { // This is an enemy 
			if ((target.gameObject.tag == "PlayerBullet") && (currentInvuln >= maxInvuln)) {
				//damage = target.PlayerBullet.damage; //variable bullet damage
				damage = 1; //temp damage amount
				currentHP -= damage;

			}
			if (currentHP < 1) {
				gameObject.SetActive (false);
			}
		}
	}

	void Update() {
		if ((maxInvuln > 0f) && (currentInvuln < maxInvuln)) {
			currentInvuln+= Time.deltaTime;
		}
	}
}
