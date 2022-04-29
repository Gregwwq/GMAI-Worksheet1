using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IdleState : FSMState<string>
{
    const string Name = "Idle";

    GameObject player;

    public IdleState(FSM<string> _fsm, GameObject _player) : base(_fsm, Name)
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