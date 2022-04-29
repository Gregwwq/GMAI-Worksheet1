using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeamState : FSMState<string>
{
    const string Name = "Beam";

    GameObject player;

    public BeamState(FSM<string> _fsm, GameObject _player) : base(_fsm, Name)
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