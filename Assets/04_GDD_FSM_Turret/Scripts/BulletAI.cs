using UnityEngine;
using System.Collections;

public class BulletAI : MonoBehaviour {

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			Destroy(gameObject);
		}
	}
}
