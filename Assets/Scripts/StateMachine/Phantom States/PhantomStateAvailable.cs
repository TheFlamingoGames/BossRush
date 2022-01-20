using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PhantomStateAvailable : State
{
    public PhantomStateAvailable(StateMachine newStateMachine) : base(newStateMachine) 
    {
        PhantomSystem.phantomState = PhantomSystem.PhantomState.AVAILABLE;        
    }

    public override IEnumerator Start()
    {
        Debug.Log("Phantom Available State Starts");

        //Wait for 2 seconds
        yield break;
    }

    public override IEnumerator Action()
    {
        Debug.Log("Phantom Available Action Starts");;
        yield break;
    }

    public override IEnumerator Pause()
    {
        Debug.Log("Phantom Available Pause Starts");
        yield break;
    }

    public override IEnumerator End()
    {
        Debug.Log("Phantom Available End Starts");
        yield break;
    }
}

