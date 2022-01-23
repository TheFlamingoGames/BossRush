using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PhantomSystem : StateMachine
{
    public static  PhantomState phantomState = PhantomState.NULL;
    public enum PhantomState
    {
        NULL,
        BEGIN,
        AVAILABLE,
        DISABLED,
        ARROW,
        DASH
    }

    public static PhantomState GetPhantomState()
    {
        return phantomState;
    }

    public static event EventHandler<OnStateStartArgs> OnStateStart;
    public class OnStateStartArgs : EventArgs
    {
        public State state;
    }

    public static event EventHandler<OnStateActionArgs> OnStateAction;
    public class OnStateActionArgs : EventArgs
    {
        public State state;
    }

    public static event EventHandler<OnStatePauseArgs> OnStatePause;
    public class OnStatePauseArgs : EventArgs
    {
        public State state;
    }

    public static event EventHandler<OnStateEndArgs> OnStateEnd;
    public class OnStateEndArgs : EventArgs
    {
        public State state;
    }

    void Start()
    {
        State s = new PhantomStateBegin(this);
        SetState(s);
    }

    public override void OnStart()
    {
        if(state?.GetType() == null) return;
        StartCoroutine(state.Start());
        OnStateStart?.Invoke(this, new OnStateStartArgs{ state = state });
    }

    public override void OnAction()
    {
        if(state?.GetType() == null) return;

        StartCoroutine(state?.Action());
        OnStateAction?.Invoke(this, new OnStateActionArgs{ state = state });
    }

    public override void OnPause()
    {
        if(state?.GetType() == null) return;

        StartCoroutine(state?.Pause());
        OnStatePause?.Invoke(this, new OnStatePauseArgs{ state = state });
    }
    
    public override void OnEnd()
    {
        if(state?.GetType() == null) return;
        StartCoroutine(state.End());
        OnStateEnd?.Invoke(this, new OnStateEndArgs{ state = state });
    }
}
