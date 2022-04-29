using UnityEngine;
using System.Collections;

public class TurnstileLockedState : FSMState<string>
{
    const string Name = "Locked";

    public TurnstileLockedState(FSM<string> _fsm) : base(_fsm, Name)
    {

    }

    public override void Enter()
    {
        Debug.Log("Waiting for a coin");
    }

    public override void Execute()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Coin inserted");
            fsm.SetState("Unlocked");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Oh no! The turnstile broke");
            fsm.SetState("Broken");
        }
    }

    public override void Exit()
    {
        Debug.Log("Coin recieved, turnstile unlocked");
    }
}

