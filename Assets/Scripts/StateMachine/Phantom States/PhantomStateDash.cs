using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PhantomStateDash : State
{
    public static event EventHandler OnPhantomStateDashStart;
    public static event EventHandler OnPhantomStateDashAction;
    public static event EventHandler OnPhantomStateDashPause;
    public static event EventHandler OnPhantomStateDashEnd;

    public PhantomStateDash(StateMachine newStateMachine) : base(newStateMachine) 
    {
        PhantomSystem.phantomState = PhantomSystem.PhantomState.DASH;
    }

    public override IEnumerator Start()
    {
        Debug.Log("Phantom Dash State Starts");
        yield break;
    }

    public override IEnumerator Action()
    {
        Debug.Log("Phantom Dash Action Starts");

        yield break;
    }

    public override IEnumerator Pause()
    {
        Debug.Log("Phantom Dash Pause Starts");

        yield break;
    }

    public override IEnumerator End()
    {
        Debug.Log("Phantom Dash End Starts");

        yield break;
    }
}

