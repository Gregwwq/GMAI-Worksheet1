using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IdleState : FSMState<string>
{
    const string Name = "Idle";

    // the main central script that manages all the states
    TurretAIFSM main;

    public IdleState(FSM<string> _fsm, TurretAIFSM _main) : base(_fsm, Name)
    {
        main = _main;
    }

    public override void Enter()
    {

    }

    public override void Execute()
    {
        // checking if the player is within tracking range
        if (main.PlayerDistanceSquared < main.MaxTrackDistanceSquared)
        {
            fsm.SetState("Track");
        }
    }

    public override void Exit()
    {

    }
}