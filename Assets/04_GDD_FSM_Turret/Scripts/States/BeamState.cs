using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeamState : FSMState<string>
{
    const string Name = "Beam";

    // the main central script that manages all the states
    TurretAIFSM main;

    public BeamState(FSM<string> _fsm, TurretAIFSM _main) : base(_fsm, Name)
    {
        main = _main;
    }

    public override void Enter()
    {
        if (main.Anim.GetBool("TrackRange") == false)
        {
            main.Anim.SetBool("TrackRange", true);
        }

        ShootLaser();
    }

    public override void Execute()
    {
        // checking if the player has exited beam range
        if (main.PlayerDistanceSquared >= main.MaxTrackDistanceSquared * 0.33f)
        {
            fsm.SetState("Missile");
        }

        // checking if the sound effect is already playing
        if (!main.Source.isPlaying)
        {
            main.Source.PlayOneShot(main.laser, 1.0f);
        }

        // tracking the player
        main.Track();


        // checking if the machine is broken
        main.CheckBroken();
    }

    public override void Exit()
    {
        StopLaser();
    }

    // function to start shooting the laser
    void ShootLaser()
    {
        main.LaserScript[0].Fire(true);
        main.LaserScript[1].Fire(true);
        main.Source.PlayOneShot(main.laser, 1.0f);
    }

    // function to stop shooting the laser
    void StopLaser()
    {
        main.LaserScript[0].Fire(false);
        main.LaserScript[1].Fire(false);
        main.Source.Stop();
    }
}