using UnityEngine;
using System.Collections;


/*
This script handles Camera movement (following or re-assigning)
*/
public class CameraFollow : MonoBehaviour {
		
	private GameObject focus;//Object for the camera to focus on

    public float smoothTimeX;//Camera movement on the X-axis, used as a way to smoothly move the camera
    public float smoothTimeY;//Camera movement on the Y-axis, used as a way to smoothly move the camera
    public bool bounds;//A check for if you want your camera bounded

    private bool reset;//Used to trigger a dampening effect on the camera reset during Fixed Update
	private Vector2 velocity;//Camera velocity used on dampening effect

    /// <summary>
    /// Since CameraFollow script is shared on all scenes, have to set stage limits separately
    /// </summary>
    ////Specific Stage Limits
    //private const float stageminX = -45f;
    //private const float stagemaxX = 165f;
    //private const float stageminY = 7f;
    //private const float stagemaxY = 9f;
    //private const float stageminZ = -1f;
    //private const float stagemaxZ = 0f;

    //General Stage Limits
    public float stageminX;
    public float stagemaxX;
    public float stageminY;
    public float stagemaxY;
    public float stageminZ;
    public float stagemaxZ;

    //Used to manipulate camera (use specific stage limits as defaults)
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    private float minZ;
    private float maxZ;

	void Start () {
        if (bounds)
        {
            SetStageCamera(stageminX, stagemaxX, stageminY, stagemaxY, stageminZ, stagemaxZ);
        }
        focus = GameObject.FindGameObjectWithTag ("Player");
    }

	void Update(){
        dampenCameraShift(focus.transform.position.x, focus.transform.position.y);
        if (reset) {
            dampenCameraShift(focus.transform.position.x, stageminY);
            reset = false;
        }

        if (bounds)
        {
            SetStageCamera(stageminX, stagemaxX, stageminY, stagemaxY, stageminZ, stagemaxZ);
        }
    }

    //Limits camera movement
    public void SetStageCamera(float minX, float maxX, float minY, float maxY, float minZ, float maxZ)
    {
        transform.position = new Vector3(
            (Mathf.Clamp(transform.position.x, minX, maxX)),
            (Mathf.Clamp(transform.position.y, minY, maxY)),
            (Mathf.Clamp(transform.position.z, minZ, maxZ))
            );
    }

    //Changes focus to GameObject with name
    public void ChangeCameraFocus(string name, bool fast)
    {
        //Debug.Log("Changing Focus to: " + name);
        focus = GameObject.Find(name);
        if (fast)
        {
            smoothTimeX = .2f;
            smoothTimeY = .2f;
        }
        else
        {
            smoothTimeX = .5f;
            smoothTimeY = .5f;
        }
        //Since focusing on a specific object in the scene, disabling bounds for now, will re-enable when reseting camera
        bounds = false;
    }

    //Re-assigns camera focus to Player, bounds reactivated, and reset triggered for camera reset dampening
    public void ResetCameraFocus() {
        //Debug.Log("Resetting Focus to: Player");
        focus = GameObject.Find("Player");
        bounds = true;
        reset = true;
    }

    //Adjusts Main Camera position to targetX and targetY gradually.
    public void dampenCameraShift(float targetX, float targetY)
    {
        float posX = Mathf.SmoothDamp(transform.position.x, targetX, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, targetY, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

    }

	public void ChangeYBounds(float newFloorBound, float newCeilingBound){
		stageminY = newFloorBound;
		stagemaxY = newCeilingBound;
		Debug.Log ("Changing floor");

	}
}
