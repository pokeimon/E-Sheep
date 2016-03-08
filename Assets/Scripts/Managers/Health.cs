using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int maxHP;
	public int playerStartHP = 2; //player starts at 2 hp
	public int currentHP; //public so it can be seen for testing
	private int damage;
	private Animator animator;
	private Rigidbody2D body2d;
	private CollisionState collisionState;

	public float knockbackForce = 30f;
	public float maxMeleeInvuln = 0.4f; //prevents same melee from hitting twice
	public float maxBulletInvuln = 0f; //disabled on default
	public float currentMeleeInvuln = 100f;
	public float currentBulletInvuln = 100f;
	public GameObject deathCanvas; //temp to get deathmenu to work

	void Awake() {
		Debug.Log ("Awake called.");
		if (this.tag == "Player") {
			Debug.Log ("Awake called.");
			currentHP = playerStartHP; 
			animator = GetComponent<Animator> ();
			animator.SetInteger("EquippedItem",1);
			body2d = GetComponent<Rigidbody2D> ();
			collisionState = GetComponent<CollisionState> ();
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
			//GAA 5 MAR 2016 Note 1: added an if statement for nested enemy structures (e.g. Flying Enemy sprite with multiple colliders)
			if (currentHP < 1) {
				if (gameObject.transform.parent != null && gameObject.transform.parent.CompareTag ("Enemy")) {
					gameObject.transform.parent.gameObject.SetActive (false);
				} else {
					gameObject.SetActive (false);
				}
			}

//			//GAA 5 MAR 2016 Note 2: Previous implementation of deactivating enemy gameobjects 
//			if(currentHP < 1){
//				gameObject.SetActive (false);
//			}
		}
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (this.tag == "Player") {
			if((target.gameObject.tag == "Enemy") && (currentMeleeInvuln >= maxMeleeInvuln)){
				float myPosX = this.transform.position.x;
				float myPosY = this.transform.position.y;
				float enemyPosX = target.gameObject.transform.position.x;
				float enemyPosY = target.gameObject.transform.position.y;
				float knockbackVelX = knockbackForce;
				float knockbackVelY = knockbackForce;

				if (myPosX < enemyPosX) { //enemy to the right
					knockbackVelX *= -1;
				}
				if(myPosY < enemyPosY){ //enemy is above
					knockbackVelY *= -1;
				}

				body2d.velocity = new Vector2(knockbackVelX,knockbackVelY);

				collisionState.stunned = true; //stuns player temporarily
				collisionState.timeStunned = 0f;

				currentHP -= 1; //player always takes 1 damage.
				currentMeleeInvuln = 0f; //make player unable to take damage for a time;
			}
			if (currentHP < 1) {
				gameObject.SetActive (false);
				DeathMenu menu = (DeathMenu) deathCanvas.GetComponent("DeathMenu");
				menu.playerDeath();
			}
		}
		else if (this.tag == "Enemy") {
			if ((target.gameObject.tag == "PlayerSword") && (currentMeleeInvuln >= maxMeleeInvuln)) {
				PlayerSword sword = target.gameObject.transform.parent.gameObject.GetComponent<PlayerSword>();
				damage = sword.damage; //get damage amount from sword
				currentHP -= damage;
				currentMeleeInvuln = 0f;
			}

			//GAA 5 MAR 2016 Note 1: added an if statement for nested enemy structures (e.g. Flying Enemy sprite with multiple colliders)
			if (currentHP < 1) {
				if (gameObject.transform.parent != null && gameObject.transform.parent.CompareTag ("Enemy")) {
					gameObject.transform.parent.gameObject.SetActive (false);
				} else {
					gameObject.SetActive (false);
				}
			}

//			//GAA 5 MAR 2016 Note 2: Previous implementation of deactivating enemy gameobjects 
//			if(currentHP < 1){
//				gameObject.SetActive (false);
//			}
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

