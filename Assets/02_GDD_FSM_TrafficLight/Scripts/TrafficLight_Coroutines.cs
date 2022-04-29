//using UnityEngine;
//using System.Collections;

//public class TrafficLight_Coroutines : MonoBehaviour {
//	public GameObject lightGreen;
//	public GameObject lightYellow;
//	public GameObject lightRed;
	
//	public float timeout = 3f;

//	State currentState;
	
//	// British sequence is: Red (STOP), then Red and Yellow (READY), then Green (GO), then back to Red
//	enum State 
//	{
//		/* Missing code */
//	}

//	void Start () {
//		currentState = /* Missing code */;
//	}
	
//	void Update()
//	{
//		if (/* Missing code */)
//		{
//			StartCoroutine(lightGo());
//		}
//		else if (/* Missing code */)
//		{
//			StartCoroutine(/* Missing code */);
//		}
//		else if (/* Missing code */)
//		{
//			StartCoroutine(/* Missing code */);
//		}
//		else
//		{
//			Debug.Log ("ERROR - no such state");
//		}
//	}
	
//	void SetState(State state)
//	{
//		currentState = state;
//	}
	
//	IEnumerator lightStop()
//	{
//		/* Missing code */

//		yield return new WaitForSeconds(timeout);
//		/* Missing code */
//	}

//	IEnumerator lightReady()
//	{
//		/* Missing code */
//	}
	
//	IEnumerator lightGo()
//	{
//		/* Missing code */
//	}

//	void setLightColor(GameObject objLight, Color color)
//	{
//		objLight.GetComponent<Renderer>().material.color = color;
//	}
//}
