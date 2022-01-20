using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class StateMachine : MonoBehaviour
{
    protected static State state;

    public void SetState(State newState)
    {
        OnEnd();
        state = newState;
        OnStart();
    }

    public static State GetState()
    {
        return state;        
    }

    public virtual void OnStart()
    {
    }

    public virtual void OnAction()
    {
    }

    public virtual void OnPause()
    {
    }
    
    public virtual void OnEnd()
    {
    }
}
