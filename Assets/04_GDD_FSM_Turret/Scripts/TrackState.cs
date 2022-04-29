using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackState : FSMState<string>
{
    const string Name = "Track";

    GameObject player;

    public TrackState(FSM<string> _fsm, GameObject _player) : base(_fsm, Name)
    {
        player = _player;
    }

    public override void Enter()
    {

    }

    public override void Execute()
    {

    }

    public override void Exit()
    {

    }
}