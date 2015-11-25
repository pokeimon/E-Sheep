using UnityEngine;
using System.Collections;

public class SummonMallow : MonoBehaviour {

	public GameObject mallowPrefab;
	GameObject actualSummon;
	public Transform summonArea;

	void OnTriggerEnter2D(Collider2D other)
	{
		//        Debug.Log("Trigger Entered");
		if (other.name == "Player")
		{
			Debug.Log ("BurnHouse triggered.");
			actualSummon = (GameObject)Instantiate(mallowPrefab, summonArea.position, summonArea.rotation);

			actualSummon.GetComponent<Mallow>().target = other.transform;
			actualSummon.GetComponent<SpriteRenderer>().color = Color.red;

			gameObject.SetActive (false);
			
		}
	}
}
