using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissleState : FSMState<string>
{
    const string Name = "Missle";

    GameObject player;

    public MissleState(FSM<string> _fsm, GameObject _player) : base(_fsm, Name)
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