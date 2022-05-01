using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BrokenState : FSMState<string>
{
    const string Name = "Broken";

    float elap = 0f;

    public BrokenState(FSM<string> _fsm) : base(_fsm, Name)
    {

    }

    public override void Enter()
    {
        elap = 0f;
        Debug.Log("The turret is broken!");
    }

    public override void Execute()
    {
        if (elap >= 3f)
        {
            Debug.Log("The turret is broken!");
            elap = 0f;
        }
        elap += Time.deltaTime;
    }

    public override void Exit()
    {

    }
}