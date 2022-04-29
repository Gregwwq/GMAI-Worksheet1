using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USARedState : FSMState<string>
{
    const string Name = "Red";

    readonly Color GreyColor = new Color(100, 100, 100);
    readonly Color RedColor = new Color(255, 0 ,0);

    GameObject redObj;
    float elap = 0f;

    public USARedState(FSM<string> _fsm, GameObject _redObj) : base(_fsm, Name)
    {
        redObj = _redObj;
    }

    public override void Enter()
    {
        elap = 0f;

        redObj.GetComponent<Renderer>().material.color = RedColor;
    }

    public override void Execute()
    {
        if (elap >= 1f)
        {
            fsm.SetState("Green");
        }
        else
        {
            elap += Time.deltaTime;
        }
    }

    public override void Exit()
    {
        redObj.GetComponent<Renderer>().material.color = GreyColor;
    }
}