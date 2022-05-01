using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackState : FSMState<string>
{
    const string Name = "Track";

    // the main central script that manages all the states
    TurretAIFSM main;

    public TrackState(FSM<string> _fsm, TurretAIFSM _main) : base(_fsm, Name)
    {
        main = _main;
    }

    public override void Enter()
    {
        main.Anim.SetBool("TrackRange", true);
    }

    public override void Execute()
    {
        // checking if the player has exited the tracking range
        if (main.PlayerDistanceSquared >= main.MaxTrackDistanceSquared)
        {
            fsm.SetState("Idle");
            return;
        }

        // checking if the player has entered the missile range
        if (main.PlayerDistanceSquared < main.MaxTrackDistanceSquared * 0.66f)
        {
            fsm.SetState("Missile");
            return;
        }

        // tracking the player
        main.Track();

        // checking if the machine is broken
        main.CheckBroken();
    }

    public override void Exit()
    {
        main.Anim.SetBool("TrackRange", false);
    }
}