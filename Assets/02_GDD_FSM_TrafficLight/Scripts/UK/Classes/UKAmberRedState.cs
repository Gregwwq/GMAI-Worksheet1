using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UKAmberRedState : FSMState<string>
{
    const string Name = "AmberRed";

    readonly Color GreyColor = new Color(100, 100, 100);
    readonly Color AmberColor = new Color(247, 255, 0);
    readonly Color RedColor = new Color(255, 0 ,0);

    GameObject amberObj, redObj;
    float elap = 0f;

    public UKAmberRedState(FSM<string> _fsm, GameObject _amberObj, GameObject _redObj) : base(_fsm, Name)
    {
        amberObj = _amberObj;
        redObj = _redObj;
    }

    public override void Enter()
    {
        elap = 0f;

        amberObj.GetComponent<Renderer>().material.color = AmberColor;
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
        amberObj.GetComponent<Renderer>().material.color = GreyColor;
        redObj.GetComponent<Renderer>().material.color = GreyColor;
    }
}