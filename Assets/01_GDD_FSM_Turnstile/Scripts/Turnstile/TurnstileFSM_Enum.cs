using UnityEngine;
using System.Collections;

public class TurnstileFSM_Enum : MonoBehaviour 
{
	enum State{Locked, Unlocked};
	State state;
    bool coin, push;

    private void Start()
    {
        // using enum to set the state instead
        state = State.Locked;
        ResetBools();

        StartCoroutine(Main());
    }

    private void Update()
    {
        if (!coin && Input.GetKeyDown(KeyCode.C))
        {
            coin = true;
            Debug.Log("Coin inserted");
        }
        if (!push && Input.GetKeyDown(KeyCode.P))
        {
            push = true;
            Debug.Log("Pushing...");
        }
    }

    private void ResetBools()
    {
        coin = false;
        push = false;
    }

    IEnumerator Main()
    {
        for (; ; )
        {
            // using enum to check the current state
            if (state == State.Locked)
            {
                if (coin)
                {
                    // using enum to set the state instead
                    state = State.Unlocked;
                    ResetBools();
                    Debug.Log("Coin recieved, turnstile unlocked");
                }
                else
                {
                    Debug.Log("Waiting for a coin");
                }
            }
            else if (state == State.Unlocked)
            {
                if (push)
                {
                    // using enum to set the state instead
                    state = State.Locked;
                    ResetBools();
                    Debug.Log("You went through the turnstile");
                }
                else
                {
                    Debug.Log("Waiting for you to push through");
                }
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
