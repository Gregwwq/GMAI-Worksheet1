using UnityEngine;
using System.Collections;

public class TurnstileFSM_Functions : MonoBehaviour
{
    enum State { Locked, Unlocked, Broken, Repairing };
    State state;

    bool coin, push, repair;
    float repairElap = 0f;

    private void Start()
    {
        state = State.Locked;
        ResetBools();

        StartCoroutine(Main());
    }

    private void Update()
    {
        // checking if the turnstile is in the broken state
        if (state != State.Broken)
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
        else
        {
            // getting input from user to repair the turnstile
            if (!repair && Input.GetKeyDown(KeyCode.R))
            {
                repair = true;
                Debug.Log("Preparing to repair");
            }
        }

        // getting input from the user to trigger the broken state
        if (Input.GetKeyDown(KeyCode.B))
        {
            state = State.Broken;
            Debug.Log("Oh no! The turnstile broke");
        }
    }

    IEnumerator Main()
    {
        for (; ; )
        {
            switch (state)
            {
                case State.Locked:
                    StateUnlocked();
                    break;

                case State.Unlocked:
                    StateLocked();
                    break;

                case State.Broken:
                    StateBroken();
                    break;

                case State.Repairing:
                    StateRepairing();
                    break;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private void ResetBools()
    {
        coin = false;
        push = false;
        repair = false;
    }

    // implementing function calls for every state
    private void StateUnlocked()
    {
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
    }

    private void StateLocked()
    {
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
    }

    private void StateBroken()
    {
        // if statement to check if the player has began the repair
        if (repair)
        {
            // changing the state to repairing
            state = State.Repairing;
            ResetBools();
            Debug.Log("Beginning repairs now");
        }
        else
        {
            Debug.Log("The turnstile needs repairing");
        }

    }

    private void StateRepairing()
    {
        // checking if the repairing has gone for more than 3 seconds
        if (repairElap > 2.9f)
        {
            // finish repairing the turnstile and changing the state back to locked
            state = State.Locked;
            repairElap = 0f;
            Debug.Log("Repaired successfully");
        }
        else
        {
            // printing out the time left for the repair to finish
            Debug.Log("Repairing... " + (3f - repairElap) + "s left");

            // incrementing by 1 because the main coroutine loop is every 1 second
            repairElap++;
        }
    }
}
