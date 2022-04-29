using UnityEngine;
using System.Collections;

public class TurnstileRepairingState : FSMState<string>
{
    const string Name = "Repairing";

    float repairElap = 0f;

    public TurnstileRepairingState(FSM<string> _fsm) : base(_fsm, Name)
    {

    }

    public override void Enter()
    {
        Debug.Log("Repairing...");
        repairElap = 0f;
    }

    public override void Execute()
    {
        if (repairElap > 2.9f)
        {
            repairElap = 0f;
            fsm.SetState("Locked");
        }
        else
        {
            Debug.Log("Time left: " + Mathf.Round(3f - repairElap) + "s");
            repairElap += Time.deltaTime;
        }
    }

    public override void Exit()
    {
        Debug.Log("Repaired successfully");
    }
}