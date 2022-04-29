using UnityEngine;
using System.Collections;

public class TurnstileFSM_String : MonoBehaviour
{
    string state;
    bool coin, push;

    private void Start()
    {
        // setting the initial state to locked
        state = "locked";
        ResetBools();

        StartCoroutine(Main());
    }

    private void Update()
    {
        // waiting for player input to when to insert the coin
        if (!coin && Input.GetKeyDown(KeyCode.C))
        {
            coin = true;
            Debug.Log("Coin inserted");
        }

        // waiting for player input to push throught the turnstile
        if (!push && Input.GetKeyDown(KeyCode.P))
        {
            push = true;
            Debug.Log("Pushing...");
        }
    }

    // a function for resetting all the booleans used by player input
    private void ResetBools()
    {
        coin = false;
        push = false;
    }

    // coroutine to run the checks at an interval of 1 second
    IEnumerator Main()
    {
        for (; ; )
        {
            // if statement to check if the state is locked or unlocked
            if (state == "locked")
            {
                // if statement to check if the player has inserted a coin
                if (coin)
                {
                    // changing the state to unlocked upon insert of coin
                    state = "unlocked";
                    ResetBools();
                    Debug.Log("Coin recieved, turnstile unlocked");
                }
                else
                {
                    Debug.Log("Waiting for a coin");
                }
            }
            else if (state == "unlocked")
            {
                // if statement to check if the player has pushed through
                if (push)
                {
                    // changing the state back to locked once pushed through
                    state = "locked";
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
