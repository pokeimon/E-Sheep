using UnityEngine;
using System.Collections;

public class PeaShooterBullet : MonoBehaviour {

    public Vector2 bulletSpeed = new Vector2(100, 0);
	public float bulletLifeTime = 2.1f;

    private Rigidbody2D body2d;

	private GameObject player;
	private Vector2 playerSpeed;

    void Awake() {
        body2d = GetComponent<Rigidbody2D>();
		player = GameObject.FindGameObjectWithTag ("Player");
    }

    void OnEnable() {

        var startVelX = bulletSpeed.x * transform.localScale.x;
		playerSpeed = player.GetComponent<Rigidbody2D>().velocity;
		/*
		if (playerSpeed.x > 0) //add player speed to bullet looks weird trying higher bullet speed
			startVelX += Mathf.Abs(playerSpeed.x); 
		else
			startVelX -= Mathf.Abs(playerSpeed.x);
		*/	
		body2d.velocity = new Vector2(startVelX, bulletSpeed.y);

		Invoke("Destroy", bulletLifeTime); //destroy after set time (3 seconds) if it doesn't collide
		//may want to find way to avoid killing off screen enemies?

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
