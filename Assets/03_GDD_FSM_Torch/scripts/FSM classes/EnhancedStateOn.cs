using UnityEngine;
using System.Collections;

public class EnhancedStateOn : FSMState<string>
{
    const string Name = "ON";

    float dist = 2.5f;

    GameObject player, tlObj;
    Torchlight tl;

    public EnhancedStateOn(FSM<string> _fsm, GameObject _player, GameObject _tlObj, Torchlight _tl) : base(_fsm, Name)
    {
        player = _player;
        tlObj = _tlObj;
        tl = _tl;
    }

    public override void Enter()
    {
        Debug.Log("Enter ON state");
        
        tl.IntensityLight = .5f;
    }

    public override void Execute()
    {
        Debug.Log("In ON state");

        if (GetPlayerSqrMag() > (dist * dist))
        {
            fsm.SetState("OFF");
            return;
        }

        tl.IntensityLight = .5f / (GetPlayerSqrMag() * .3f);
        
        if (tl.IntensityLight < .5f) tl.IntensityLight = .5f;
    }

    public override void Exit()
    {
        Debug.Log("Exit ON state");
    }

    float GetPlayerSqrMag()
    {
        return (player.transform.position - tlObj.transform.position).sqrMagnitude;
    }
}
