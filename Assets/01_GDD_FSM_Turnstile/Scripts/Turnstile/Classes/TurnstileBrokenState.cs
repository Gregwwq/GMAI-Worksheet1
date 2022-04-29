using UnityEngine;
using System.Collections;

public class TurnstileBrokenState : FSMState<string>
{
    const string Name = "Broken";

    public TurnstileBrokenState(FSM<string> _fsm) : base(_fsm, Name)
    {

    }

    public override void Enter()
    {
        Debug.Log("The turnstile needs repairing");
    }

    public override void Execute()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Preparing to repair");
            fsm.SetState("Repairing");
        }
    }

    public override void Exit()
    {
        Debug.Log("Beginning repairs now");
    }
}
