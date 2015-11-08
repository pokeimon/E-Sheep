using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

    public Vector2 bulletSpeed = new Vector2(100, 0);
	public float bulletLifeTime = 2.1f;
	public int damage;

    private Rigidbody2D body2d;

	private GameObject player;
	private Vector2 playerSpeed;

    void Awake() {
        body2d = GetComponent<Rigidbody2D>();
		player = GameObject.FindGameObjectWithTag ("Player");
		this.transform.SetParent(player.transform);

    }

    void OnEnable() {
		//damage = player.health.currentHP - 1;

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
