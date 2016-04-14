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
				Sword sword = target.gameObject.transform.parent.gameObject.GetComponent<Sword>();
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
		else if(this.tag == "CL2Boss"){ //added by ivan on 03/31/2016 for boss Testing
			if ((target.gameObject.tag == "PlayerSword") && (currentMeleeInvuln >= maxMeleeInvuln) && this.gameObject.GetComponent<FrogTongue>().autostart == true) {
				Sword sword = target.gameObject.transform.parent.gameObject.GetComponent<Sword>();
				//damage = sword.damage; //get damage amount from sword
				damage = 1;
				this.gameObject.GetComponent<FrogTongue> ().hit = true;
				currentHP -= damage;
				//StartCoroutine ("damageAnimation");
				//StartCoroutine("damageAnim", this.gameObject.transform.parent);
				//damageAnimHandler(this.gameObject.transform.parent.FindChild("sample_boss_head"), "clBoss");
				object[] parameters = new object[3]{this.gameObject.transform.parent.FindChild("sample_boss_head"), Color.red, Color.magenta};
				StartCoroutine ("damageAnim", parameters);

				currentMeleeInvuln = 0f;
			}
			if (currentHP < 1) {
				Debug.Log ("Here");
				object[] parameters = new object[4]{this.gameObject.transform.parent.FindChild("sample_boss_head"), Color.white, Color.clear, "death"};
				StartCoroutine ("damageAnim", parameters);
				/*
				if (gameObject.transform.parent != null && gameObject.transform.parent.CompareTag ("CL2Boss")) {
					gameObject.transform.parent.gameObject.SetActive (false);
				} else {
					//gameObject.SetActive (false);//disables just tongue
					gameObject.transform.parent.gameObject.SetActive (false);//disables head and tongue
				}
				*/
			}
		}
	}
		

/*
	public IEnumerator damageAnimation()// for Candy Land boss
	{
		for (int i=0; i<25; i++) 
		{
			gameObject.transform.parent.FindChild ("sample_boss_head").GetComponent<SpriteRenderer> ().color = Color.Lerp(Color.red, Color.magenta, (float)(i/(25f)));
			yield return new WaitForSeconds (0.01f);
		}
		gameObject.transform.parent.FindChild ("sample_boss_head").GetComponent<SpriteRenderer> ().color = Color.magenta;
		//yield return new WaitForSeconds (1f);
		for (int j=0; j<25; j++) 
		{
			gameObject.transform.parent.FindChild ("sample_boss_head").GetComponent<SpriteRenderer> ().color = Color.Lerp(Color.magenta, Color.red, (float)(j/(25f)));
			yield return new WaitForSeconds (0.01f);
		}
		gameObject.transform.parent.FindChild ("sample_boss_head").GetComponent<SpriteRenderer> ().color = Color.red;
		for (int k=0; k<25; k++) 
		{
			gameObject.transform.parent.FindChild ("sample_boss_head").GetComponent<SpriteRenderer> ().color = Color.Lerp(Color.red, Color.white, (float)(k/(25f)));
			yield return new WaitForSeconds (0.01f);
		}
	}
*/
	public IEnumerator damageAnim(object[] p)// for Candy Land boss
	{
		Transform anObject = (Transform)p [0];
		Color a = (Color)p [1];
		Color b = (Color)p [2];

		float t = 15;

		//Temp solution to death state for tongue
		if(p.Length == 4 && ((string)p[3]).Equals("death")){
			this.gameObject.transform.FindChild ("Ground").GetComponent<SpriteRenderer> ().color = Color.clear;
		}


		for (int i=0; i< t; i++) 
		{
			anObject.GetComponent<SpriteRenderer> ().color = Color.Lerp(a, b, (float)(i/(t)));
			yield return new WaitForSeconds (0.01f);
		}
		anObject.GetComponent<SpriteRenderer> ().color = Color.magenta;
		//yield return new WaitForSeconds (1f);
		for (int j=0; j<25; j++) 
		{
			anObject.GetComponent<SpriteRenderer> ().color = Color.Lerp(a, b, (float)(j/(t)));
			yield return new WaitForSeconds (0.01f);
		}
		anObject.GetComponent<SpriteRenderer> ().color = Color.red;
		for (int k=0; k<25; k++) 
		{
			anObject.GetComponent<SpriteRenderer> ().color = Color.Lerp(a, b, (float)(k/(t)));
			yield return new WaitForSeconds (0.01f);
		}
		yield return new WaitForSeconds (1f);
		if(p.Length == 4 && ((string)p[3]).Equals("death")){
			anObject.parent.gameObject.SetActive (false);
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

