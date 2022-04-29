using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TorchFSMClass : MonoBehaviour
{
    FSM<string> fsm = new FSM<string>();
    FSMState<string> onState, offState;

    GameObject player, tlObj;
    Torchlight tl;

    public TorchFSMClass()
    {

    }

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        tlObj = GameObject.Find("Torch");
        tl = GetComponent<Torchlight>();

        onState = new StateOn(fsm, player, tlObj, tl);
        offState = new StateOff(fsm, player, tlObj, tl);

        fsm.AddState(onState);
        fsm.AddState(offState);

        fsm.SetState("OFF");
    }

    void Update()
    {
        fsm.Update();
    }
}