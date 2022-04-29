using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UKTrafficLightFSM : MonoBehaviour
{
    readonly Color GreyColor = new Color(100, 100, 100);

    GameObject greenObj, redObj, amberObj;

    FSM<string> fsm = new FSM<string>();
    FSMState<string> greenState, amberState, redState, amberRedState;

    public UKTrafficLightFSM()
    {

    }

    void Start()
    {
        greenObj = GameObject.Find("LightGreen");
        amberObj = GameObject.Find("LightYellow");
        redObj = GameObject.Find("LightRed");

        greenObj.GetComponent<Renderer>().material.color = GreyColor;
        amberObj.GetComponent<Renderer>().material.color = GreyColor;
        redObj.GetComponent<Renderer>().material.color = GreyColor;

        greenState = new UKGreenState(fsm, greenObj);
        amberState = new UKAmberState(fsm, amberObj);
        redState = new UKRedState(fsm, redObj);
        amberRedState = new UKAmberRedState(fsm, amberObj, redObj);

        fsm.AddState(greenState);
        fsm.AddState(amberState);
        fsm.AddState(redState);
        fsm.AddState(amberRedState);

        fsm.SetState("Green");
    }

    void Update()
    {
        fsm.Update();
    }
}
