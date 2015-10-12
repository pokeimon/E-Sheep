using UnityEngine;
using System.Collections;

public class Climb : MonoBehaviour {

    public bool onLadder;
    private Rigidbody2D myrigidbody2D;

    public float climbSpeed;
    private float climbVelocity;
    private float gravityStore;

    // Use this for initialization
    void Start () {
        onLadder = false;
        myrigidbody2D = GetComponent<Rigidbody2D>();

        gravityStore = myrigidbody2D.gravityScale;
        //Debug.Log("GravityStore = " + gravityStore);
    }


    void Update()
    {
        //Debug.Log("onLadder? " + onLadder);
        if (onLadder)
        {
            myrigidbody2D.gravityScale = 0f;

            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");

            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, climbVelocity);

        }
        if (!onLadder)
        {
            myrigidbody2D.gravityScale = gravityStore;
        }
    }
}
