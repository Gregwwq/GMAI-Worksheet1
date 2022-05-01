using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissileState : FSMState<string>
{
    const string Name = "Missile";

    // the main central script that manages all the states
    TurretAIFSM main;

    int missileNum = 0;
    int maxMissileNum;
    float time = 0f;
    float bulletSpeed = 10f;
    float shootDelay = .25f;

    public MissileState(FSM<string> _fsm, TurretAIFSM _main) : base(_fsm, Name)
    {
        main = _main;

        maxMissileNum = main.SpawnPts.Count - 1;
    }

    public override void Enter()
    {
        if (main.Anim.GetBool("TrackRange") == false)
        {
            main.Anim.SetBool("TrackRange", true);
        }
    }

    public override void Execute()
    {
        // checking if the player is further than the missle range
        if (main.PlayerDistanceSquared >= main.MaxTrackDistanceSquared * 0.66f)
        {
            fsm.SetState("Track");
            return;
        }

        // checking if the player has entered the beam range
        if (main.PlayerDistanceSquared < main.MaxTrackDistanceSquared * 0.33f)
        {
            fsm.SetState("Beam");
            return;
        }

        // tracking and shooting at the player
        main.Track();
        ShootBullet();

        // checking if the machine is broken
        main.CheckBroken();
    }

    public override void Exit()
    {
        main.Anim.SetBool("ShootRange", false);
    }

    // function to shoot bullets at the player
    void ShootBullet()
    {
        time += Time.deltaTime;
        if (missileNum > maxMissileNum)
        {
            missileNum = 0;
        }

        Rigidbody bulletClone;

        if (time > shootDelay)
        {
            bulletClone = (Rigidbody)GameObject.Instantiate(main.bullet, main.SpawnPts[missileNum].position, Quaternion.identity);
            bulletClone.rotation = main.SpawnPts[missileNum].rotation;
            bulletClone.AddForce(main.SpawnPts[missileNum].forward * bulletSpeed, ForceMode.Force);

            missileNum++;
            time = 0.0f;
        }
    }
}