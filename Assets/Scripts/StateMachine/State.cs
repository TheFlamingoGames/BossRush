using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class State : MonoBehaviour
{
    protected StateMachine statemachine;

    public State(StateMachine newStateMachine)
    {
        statemachine = newStateMachine;
    }

    public virtual IEnumerator Start() 
    {
        yield break;    
    }

    public virtual IEnumerator End()
    {
        yield break;
    }

    public virtual IEnumerator Pause()
    {
        yield break;
    }

    public virtual IEnumerator Action()
    {
        yield break;
    }
}
