using UnityEngine;
using System.Collections;

public class TurnstileFSM_Switch : MonoBehaviour
{
    enum State { Locked, Unlocked };
    State state;
    bool coin, push;

    private void Start()
    {
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
            // using a switch case instead of an if statement
            switch (state)
            {
                case State.Locked:
                    if (coin)
                    {
                        state = State.Unlocked;
                        ResetBools();
                        Debug.Log("Coin recieved, turnstile unlocked");
                    }
                    else
                    {
                        Debug.Log("Waiting for a coin");
                    }
                    break;

                case State.Unlocked:
                    if (push)
                    {
                        state = State.Locked;
                        ResetBools();
                        Debug.Log("You went through the turnstile");
                    }
                    else
                    {
                        Debug.Log("Waiting for you to push through");
                    }
                    break;
                
                default:
                    Debug.Log("ERROR - no valid state!");
                    break;
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
