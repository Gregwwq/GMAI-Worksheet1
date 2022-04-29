using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USATrafficLightFSM : MonoBehaviour
{
    readonly Color GreyColor = new Color(100, 100, 100);

    GameObject greenObj, amberObj, redObj;

    FSM<string> fsm = new FSM<string>();
    FSMState<string> greenState, amberState, redState;

    public USATrafficLightFSM()
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

        greenState = new USAGreenState(fsm, greenObj);
        amberState = new USAAmberState(fsm, amberObj);
        redState = new USARedState(fsm, redObj);

        fsm.AddState(greenState);
        fsm.AddState(amberState);
        fsm.AddState(redState);

        fsm.SetState("Green");
    }

    void Update()
    {
        fsm.Update();
    }
}
