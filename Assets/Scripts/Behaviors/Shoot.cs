using UnityEngine;
using System.Collections;

public class Shoot : AbstractBehavior {

    public float shootDelay = .1f;
    public GameObject projectilePrefab;
    public Vector2 firePosition = Vector2.zero;
    public Color debugColor = Color.yellow;
    public float debugRadius = 3.5f;
	public bool shooting = false;

    private float timeElapsed = 0f;

	// Update is called once per frame
	void Update () {

        if (projectilePrefab != null) {

			var canFire = inputState.GetButtonValue (inputButtons [0]);

			if(canFire){
				shooting = true; //shooting animation

			}else { shooting = false;}

			if (canFire && timeElapsed > shootDelay) {
                GameObject obj = ObjectPooler.current.getPooledObject();

                if (obj != null)
                {
                    obj.transform.position = CalculateFirePosition();
                    obj.transform.rotation = transform.rotation;
                    obj.transform.localScale = transform.localScale * .2f;
                    obj.SetActive(true);
                    
                }
                timeElapsed = 0;	 
			}
			timeElapsed += Time.deltaTime;
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
