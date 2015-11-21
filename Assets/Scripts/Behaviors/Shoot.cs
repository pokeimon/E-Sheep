using UnityEngine;
using System.Collections;

public class Shoot : AbstractBehavior {

    public float shootDelay = .1f;
    public GameObject projectilePrefab;
    public Vector2 firePosition = Vector2.zero;
    public Color debugColor = Color.yellow;
    public float debugRadius = 3.5f;
	public bool shooting = false;

    private float curretShootDelay = 0f;
	
	void Update () {
        if (projectilePrefab != null) {

			var shootButton = inputState.GetButtonValue (inputButtons [0]);
			var up = inputState.GetButtonValue (inputButtons [1]);
			var down = inputState.GetButtonValue (inputButtons [2]);

			if(shootButton){
				shooting = true; //shooting animation
			}
			else { 
				shooting = false;
			}


			if (shootButton && curretShootDelay > shootDelay) {
                GameObject obj = ObjectPooler.current.getPooledObject();

                if (obj != null){			
                    obj.transform.position = CalculateFirePosition();
                    obj.transform.rotation = transform.rotation;
                    obj.transform.localScale = transform.localScale * .2f;
					Rigidbody2D body2d = obj.GetComponent<Rigidbody2D>();
                    obj.SetActive(true);
					if (up && !down){
						body2d.velocity = new Vector2(body2d.velocity.y , Mathf.Abs(body2d.velocity.x));
					}
					else if (!up && down){
						body2d.velocity = new Vector2(body2d.velocity.y , Mathf.Abs(body2d.velocity.x) * -1);
					}
                    
                }
				curretShootDelay = 0;	 
			}
			curretShootDelay += Time.deltaTime;
		} 
	}

    Vector2 CalculateFirePosition() {
        var pos = firePosition;
        if(inputState != null)
            pos.x *= (float)inputState.direction;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        return pos;
    }

    void OnDrawGizmos() {
        var pos = firePosition;
        if(inputState != null)
            pos.x *= (float)inputState.direction;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        Gizmos.color = debugColor;
        Gizmos.DrawWireSphere(pos, debugRadius);
    }
}
