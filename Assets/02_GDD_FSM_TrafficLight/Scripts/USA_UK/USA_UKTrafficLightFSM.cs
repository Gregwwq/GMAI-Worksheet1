using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USA_UKTrafficLightFSM : MonoBehaviour
{
    readonly Color GreyColor = new Color(100, 100, 100);

    GameObject greenObj, amberObj, redObj;

    FSM<string> usafsm = new FSM<string>();
    FSMState<string> usaGreenState, usaAmberState, usaRedState;

    FSM<string> ukfsm = new FSM<string>();
    FSMState<string> ukGreenState, ukAmberState, ukRedState, ukAmberRedState;



    enum Mode { USA, UK };
    Mode mode;

    void Start()
    {
        greenObj = GameObject.Find("LightGreen");
        amberObj = GameObject.Find("LightYellow");
        redObj = GameObject.Find("LightRed");

        greenObj.GetComponent<Renderer>().material.color = GreyColor;
        amberObj.GetComponent<Renderer>().material.color = GreyColor;
        redObj.GetComponent<Renderer>().material.color = GreyColor;

        InitializeUSA();
        InitializeUK();

        mode = Mode.UK;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (mode == Mode.USA) mode = Mode.UK;
            else if (mode == Mode.UK) mode = Mode.USA;
            
            ResetFSMs();
            Debug.Log("Switched to " + mode);
        }

        switch (mode)
        {
            case Mode.USA:
                usafsm.Update();
                break;

            case Mode.UK:
                ukfsm.Update();
                break;
        }
    }

    void ResetFSMs()
    {
        usafsm.SetState("Green");
        ukfsm.SetState("Green");
    }

    void InitializeUSA()
    {
        usaGreenState = new USAGreenState(usafsm, greenObj);
        usaAmberState = new USAAmberState(usafsm, amberObj);
        usaRedState = new USARedState(usafsm, redObj);

        usafsm.AddState(usaGreenState);
        usafsm.AddState(usaAmberState);
        usafsm.AddState(usaRedState);

        usafsm.SetState("Green");
    }

    void InitializeUK()
    {
        ukGreenState = new UKGreenState(ukfsm, greenObj);
        ukAmberState = new UKAmberState(ukfsm, amberObj);
        ukRedState = new UKRedState(ukfsm, redObj);
        ukAmberRedState = new UKAmberRedState(ukfsm, amberObj, redObj);

        ukfsm.AddState(ukGreenState);
        ukfsm.AddState(ukAmberState);
        ukfsm.AddState(ukRedState);
        ukfsm.AddState(ukAmberRedState);

        ukfsm.SetState("Green");
    }
}
