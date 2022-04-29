using UnityEngine;
using System.Collections;

public class TurnstileFSMClass : MonoBehaviour
{
    // initializing the fsm
    FSM<string> fsm = new FSM<string>();
    FSMState<string> lockedState, unlockedState, brokenState, repairingState;

    public TurnstileFSMClass()
    {
        lockedState = new TurnstileLockedState(fsm);
        unlockedState = new TurnstileUnlockedState(fsm);
        brokenState = new TurnstileBrokenState(fsm);
        repairingState = new TurnstileRepairingState(fsm);
    }

    void Start()
    {
        // adding the states
        fsm.AddState(lockedState);
        fsm.AddState(unlockedState);
        fsm.AddState(brokenState);
        fsm.AddState(repairingState);

        // starting on the locked state
        fsm.SetState("Locked");
    }

    void Update()
    {
        fsm.Update();
    }
}
