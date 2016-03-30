using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

    public Vector2 bulletSpeed = new Vector2(100, 0);
	public float bulletLifeTime = 3f;
	public int damage;
	
    private Rigidbody2D body2d;
	public GameObject player;
	public GameObject objPool;
	public Health health;
	private Vector2 playerSpeed;

    void Awake() {
        body2d = GetComponent<Rigidbody2D>();
		player = GameObject.Find ("Player");
		health = player.GetComponent<Health>();
		objPool = GameObject.Find("PlayerBulletObjectPool");
		this.transform.SetParent(objPool.transform);
    }

    void OnEnable() {
		if (health.currentHP <= 3) {
			damage = 1; 
		}
		else
		{
			damage = 2; //double damage at full health
		}

        var startVelX = bulletSpeed.x * transform.localScale.x;
		playerSpeed = player.GetComponent<Rigidbody2D>().velocity;
		body2d.velocity = new Vector2(startVelX, bulletSpeed.y);

		Invoke("Destroy", bulletLifeTime); //destroy after set time if it doesn't collide

    }

    void OnCollisionEnter2D(Collision2D target) {
        Destroy();
    }

    void Destroy() {
        gameObject.SetActive(false);
    }

    void OnDisable() {
        CancelInvoke();
    }
}
