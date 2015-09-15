using UnityEngine;
using System.Collections;

public class MovementTest : MonoBehaviour {

	public float speed = 10f;
    public float jumpSpeed = 100f;

    private bool isOnPlatform = true;
    private bool jump = false;
	private Rigidbody2D body2d;

    // Use this for initialization
	void Start ()
    {
		body2d = GetComponent<Rigidbody2D> ();
	}

    //Checks if player is on a platform before it can jump
    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
            isOnPlatform = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
            isOnPlatform = false;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnPlatform)
            jump = true;
        else
            jump = false;
    }

    // Update is called once per frame
    void Update ()
    {
        Jump();
		var horizontal = Input.GetAxis ("Horizontal");  
		body2d.velocity = new Vector2(speed * horizontal, body2d.velocity.y);
	}

    void FixedUpdate ()
    {
        if(jump)
            body2d.velocity = new Vector2(body2d.velocity.x, jumpSpeed);
    }
}
