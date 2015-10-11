using UnityEngine;
using System.Collections;

public class PeaShooterBullet : MonoBehaviour {

    public Vector2 bulletSpeed = new Vector2(80, 0);

    private Rigidbody2D body2d;

    void Awake() {
        body2d = GetComponent<Rigidbody2D>();
    }

    void OnEnable() {

        var startVelX = bulletSpeed.x * transform.localScale.x;
        body2d.velocity = new Vector2(startVelX, bulletSpeed.y);
        Invoke("Destroy", 3f); //destroy after set time (3 seconds) if it doesn't collide

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
