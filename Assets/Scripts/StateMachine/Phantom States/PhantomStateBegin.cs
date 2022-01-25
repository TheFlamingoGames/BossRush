using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PhantomStateBegin : State
{
    public PhantomStateBegin(StateMachine newStateMachine) : base(newStateMachine) 
    {
        PhantomSystem.phantomState = PhantomSystem.PhantomState.BEGIN;
    }

    public override IEnumerator Start()
    {
        Debug.Log("Phantom Begin State Starts");

        //Wait for 2 seconds
        yield return new WaitForSeconds(0f);

        //Start Other State
        statemachine.SetState(new PhantomStateAvailable(statemachine));
    }

    public override IEnumerator Action()
    {
        Debug.Log("Phantom Begin Action Starts");
        yield break;
    }

    public override IEnumerator Pause()
    {
        Debug.Log("Phantom Begin Pause Starts");
        yield break;
    }

    public override IEnumerator End()
    {
        Debug.Log("Phantom Begin End Starts");
        yield break;
    }
}
