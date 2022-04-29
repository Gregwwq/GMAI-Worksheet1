using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretAIFSM : MonoBehaviour
{
    FSM<string> fsm = new FSM<string>();
    FSMState<string> idleState, trackState, missleState, beamState;

    GameObject player;

    public TurretAIFSM()
    {

    }

    void Start()
    {
        player = GameObject.Find("");

        idleState = new IdleState(fsm, player);
        trackState = new TrackState(fsm, player);
        missleState = new MissleState(fsm, player);
        beamState = new BeamState(fsm, player);

        fsm.Add(idleState);
        fsm.Add(trackState);
        fsm.Add(missleState);
        fsm.Add(beamState);

        fsm.SetState("Idle");
    }

    void Update()
    {
        fsm.Update();
    }
}