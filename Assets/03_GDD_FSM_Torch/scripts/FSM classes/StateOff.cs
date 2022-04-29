using UnityEngine;
using System.Collections;

public class StateOff : FSMState<string>
{
    const string Name = "OFF";

    float dist = 2.5f;

    GameObject player, tlObj;
    Torchlight tl;

    public StateOff(FSM<string> _fsm, GameObject _player, GameObject _tlObj, Torchlight _tl) : base(_fsm, Name)
    {
        player = _player;
        tlObj = _tlObj;
        tl = _tl;
    }

    public override void Enter()
    {
        Debug.Log("Enter OFF state");

        tl.IntensityLight = 0f;
    }

    public override void Execute()
    {
        Debug.Log("In OFF state");

        if (GetPlayerSqrMag() <= (dist * dist))
        {
            fsm.SetState("ON");
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit OFF state");
    }

    float GetPlayerSqrMag()
    {
        return (player.transform.position - tlObj.transform.position).sqrMagnitude;
    }
}
