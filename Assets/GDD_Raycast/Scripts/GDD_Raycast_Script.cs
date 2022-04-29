using UnityEngine;
using System.Collections;

public class GDD_Raycast_Script : MonoBehaviour {

	public float distance = 2.0f;
	public Material hitMaterial;

	private GameObject target;
	private Material targetMaterial;

	private Vector3 origin;
	private Vector3 targetDirection;
		
	void Start () {
		// Delete for moveable
		target = GameObject.FindGameObjectWithTag("Target");
		targetMaterial = target.GetComponent<Renderer>().material;
		StartCoroutine("checkHitCoroutine"); 
	}

	void Update () {
		//checkHit ();
		//checkHitMoveable ();
	}

	void checkHit()
	{
		Vector3 direction = transform.forward;
		RaycastHit hit;
		
		if(Physics.Raycast (origin, direction, out hit) == true)
		{
			Debug.Log ("Hit " + hit.collider.gameObject.name);
		}
		
		//Debug.DrawRay (origin, direction * distance, Color.red);
	}

	void checkHitMoveable() 
	{
		targetDirection = GameObject.FindGameObjectWithTag ("Cube").transform.position;
		Vector3 direction = targetDirection - origin;
		RaycastHit hit;

		if(Physics.Raycast (origin, direction, out hit, distance) == true)
		{
			Debug.Log ("Hit " + hit.collider.gameObject.name);
		}

		Debug.DrawRay (origin, direction.normalized * distance, Color.red);
	}

	IEnumerator checkHitCoroutine() 
	{
		while(true)
		{
			origin = transform.position;
			targetDirection = target.transform.position; 
			Vector3 direction = targetDirection - origin;
			RaycastHit hit;
			
			if(Physics.Raycast (origin, direction, out hit, distance) == true)
			{
				Debug.Log ("Hit " + hit.collider.gameObject.name);
				target.GetComponent<Renderer>().material = hitMaterial;
			}
			else
			{
				target.GetComponent<Renderer>().material = targetMaterial;
			}
			
			Debug.DrawRay (origin, direction.normalized * distance, Color.red, 1.0f);

			yield return null;
		}
	}
}
