using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PhantomStateArrow : State
{
    public static event EventHandler OnPhantomStateArrowStart;
    public static event EventHandler OnPhantomStateArrowAction;
    public static event EventHandler OnPhantomStateArrowPause;
    public static event EventHandler OnPhantomStateArrowEnd;

    public PhantomStateArrow(StateMachine newStateMachine) : base(newStateMachine) 
    {
        PhantomSystem.phantomState = PhantomSystem.PhantomState.ARROW;
    }

    public override IEnumerator Start()
    {
        Debug.Log("Phantom Arrow State Starts");

        yield break;
    }

    public override IEnumerator Action()
    {
        Debug.Log("Phantom Arrow Action Starts");

        yield break;
    }

    public override IEnumerator Pause()
    {
        Debug.Log("Phantom Arrow Pause Starts");

        yield break;
    }

    public override IEnumerator End()
    {
        Debug.Log("Phantom Arrow End Starts");

        yield break;
    }
}
