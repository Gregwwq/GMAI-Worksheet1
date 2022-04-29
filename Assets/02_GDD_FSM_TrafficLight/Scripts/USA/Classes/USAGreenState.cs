using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USAGreenState : FSMState<string>
{
    const string Name = "Green";

    readonly Color GreyColor = new Color(100, 100, 100);
    readonly Color GreenColor = new Color(0, 255, 0);

    GameObject greenObj;
    float elap = 0f;

    public USAGreenState(FSM<string> _fsm, GameObject _greenObj) : base(_fsm, Name)
    {
        greenObj = _greenObj;
    }

    public override void Enter()
    {
        elap = 0f;

        greenObj.GetComponent<Renderer>().material.color = GreenColor;
    }

    public override void Execute()
    {
        if (elap >= 1f)
        {
            fsm.SetState("Amber");
        }
        else
        {
            elap += Time.deltaTime;
        }
    }

    public override void Exit()
    {
        greenObj.GetComponent<Renderer>().material.color = GreyColor;
    }
}