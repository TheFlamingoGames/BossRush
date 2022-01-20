using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PhantomStateDisabled : State
{
    public PhantomStateDisabled(StateMachine newStateMachine) : base(newStateMachine) 
    {
        PhantomSystem.phantomState = PhantomSystem.PhantomState.DISABLED;
    }

    public override IEnumerator Start()
    {
        Debug.Log("Phantom Disabled State Starts");

        yield break;
    }

    public override IEnumerator Action()
    {
        Debug.Log("Phantom Disabled Action Starts");

        yield break;
    }

    public override IEnumerator Pause()
    {
        Debug.Log("Phantom Disabled Pause Starts");

        yield break;
    }

    public override IEnumerator End()
    {
        Debug.Log("Phantom Disabled End Starts");

        yield break;
    }
}
