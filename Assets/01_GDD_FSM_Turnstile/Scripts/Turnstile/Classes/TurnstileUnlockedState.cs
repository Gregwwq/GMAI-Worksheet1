using UnityEngine;
using System.Collections;

public class TurnstileUnlockedState : FSMState<string>
{
    const string Name = "Unlocked";

    public TurnstileUnlockedState(FSM<string> _fsm) : base(_fsm, Name)
    {

    }

    public override void Enter()
    {
        Debug.Log("Waiting for you to push through");
    }

    public override void Execute()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Pushing...");
            fsm.SetState("Locked");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Oh no! The turnstile broke");
            fsm.SetState("Broken");
        }
    }

    public override void Exit()
    {
        Debug.Log("You went through the turnstile");
    }
}