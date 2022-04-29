using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USAAmberState : FSMState<string>
{
    const string Name = "Amber";

    readonly Color GreyColor = new Color(100, 100, 100);
    readonly Color AmberColor = new Color(247, 255, 0);

    GameObject amberObj;
    float elap = 0f;

    public USAAmberState(FSM<string> _fsm, GameObject _amberObj) : base(_fsm, Name)
    {
        amberObj = _amberObj;
    }

    public override void Enter()
    {
        elap = 0f;

        amberObj.GetComponent<Renderer>().material.color = AmberColor;
    }

    public override void Execute()
    {
        if (elap >= 1f)
        {
            fsm.SetState("Red");
        }
        else
        {
            elap += Time.deltaTime;
        }
    }

    public override void Exit()
    {
        amberObj.GetComponent<Renderer>().material.color = GreyColor;
    }
}