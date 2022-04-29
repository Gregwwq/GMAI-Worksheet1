using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AdaptableStateMachine;
using AdaptableStateMachine.FunStateMachine;

public class FunController : MonoBehaviour
{
    public Text outText;
    public InputField inText;

    IStateMachine machine;

    void Start ()
    {
        machine = new FunMachine();
	}

    public void HandleInput()
    {
        string nextState = inText.text;
        machine.Advance(nextState);
        inText.text = "";
    }

    void Update()
    {
        outText.text = "Currently in " + machine.CurrentState;
        outText.text += "\nAvailable choices are:\n";

        string[] transitions = machine.PossibleTransitions();
        foreach (string item in transitions)
        {
            outText.text += "\n " + item;
        }

        // Request a transition from the user
        outText.text += "\n\nWhat do you want to do?";
    }
}
