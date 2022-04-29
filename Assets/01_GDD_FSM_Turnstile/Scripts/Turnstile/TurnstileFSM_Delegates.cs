//// http://unity3d.com/learn/tutorials/modules/intermediate/scripting/delegates

//using UnityEngine;
//using System.Collections;

//public class TurnstileFSM_Delegates : MonoBehaviour 
//{
//	enum State 
//	{
//		locked, 
//		unlocked
//	};

//	delegate void StateDelegateFunction();
//	StateDelegateFunction stateFunc;

//	State currentState;
//	StateDelegateFunction lockStateDelegate;
//	StateDelegateFunction unlockStateDelgate;

//	void Start () 
//	{
//		lockStateDelegate = new StateDelegateFunction(lockTurnstile);
//		unlockStateDelgate = new StateDelegateFunction(unlockTurnstile);

//		currentState = State.locked;
//		stateFunc = // Missing code
//	}

//	void Update () 
//	{
//		if(currentState == /* Missing code */)
//		{
//			bool coin = checkCoin ();
//			if(coin)
//			{
//				SetState (State.unlocked, /* Missing code */);
//			}
//		} 
//		else if (/* Missing code */)
//		{
//			bool push = checkPush ();
//			if(push)
//			{
//				pushTurnstile();
//				/* Missing code */
//			}
//		}

//		stateFunc();
//	}

//	void SetState(State nextState, StateDelegateFunction function)
//	{
//		currentState = nextState;
//		stateFunc = /* Missing code */;
//	}

//	void lockTurnstile()
//	{
//		Debug.Log ("LOCKED! Waiting for a coin");
//	}

//	void unlockTurnstile()
//	{
//		Debug.Log ("UNLOCKED! Waiting for a push");
//	}
	
//	void pushTurnstile()
//	{
//		Debug.Log ("You just went through the turnstile!");
//	}
	
//	bool checkCoin()
//	{
//		if(Random.Range(0, 10) >= 8f)
//		{
//			return true;
//		} 
//		return false;
//	}

//	bool checkPush()
//	{
//		if(Random.Range(0, 10) >= 3f)
//		{
//			return true;
//		}
//		return false;
//	}
//}
