using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AbilityHandler : MonoBehaviour
{
    [SerializeField] GameObject phantom;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject dashOrb;

    [SerializeField] DashOrb dashOrbScript;

    [SerializeField] GameObject player;
    [SerializeField] BodyMovement playerMovement;
    int count;
    StateMachine phantomSystem => PhantomSystem.GetState().statemachine;

    PhantomSystem.PhantomState phantomState => PhantomSystem.GetPhantomState();

    void Awake()
    {
        playerMovement = player.GetComponent<BodyMovement>();
        dashOrbScript = dashOrb.GetComponent<DashOrb>();
    }

    void Start()
    {
        PhantomSystem.OnStateStart += ToggleToPhantom;

        InputManager.instance.OnDashPressed += ToggleToDashOrb;
        InputManager.instance.OnDashReleased += ToggleFromDashOrb;

        InputManager.instance.OnArrowPressed += ToggleToArrow;
    }

//Phantom
    void ToggleToPhantom(object sender, PhantomSystem.OnStateStartArgs e)
    {
        if(phantomState != PhantomSystem.PhantomState.AVAILABLE) return;
        playerMovement.SetDash(false);
        arrow.SetActive(false);
        dashOrb.SetActive(false);

        phantom.transform.position = player.transform.position;
        phantom.transform.rotation = player.transform.rotation;
        phantom.SetActive(true);
    }
    void ToggleFromPhantom(object sender, EventArgs e)
    {
        if(phantomState != PhantomSystem.PhantomState.AVAILABLE) return;
    }

//Arrow
    void ToggleToArrow(object sender, EventArgs e)
    {
        if(phantomState != PhantomSystem.PhantomState.AVAILABLE) return;
        phantom.SetActive(false);
        dashOrb.SetActive(false);

        arrow.transform.position = player.transform.position + Vector3.up;
        arrow.transform.rotation = player.transform.rotation;
        arrow.SetActive(true);

        phantomSystem.SetState(new PhantomStateArrow(phantomSystem));
    }
    void ToggleFromArrow(object sender, EventArgs e)
    {
        if(phantomState != PhantomSystem.PhantomState.ARROW) return;
        phantomSystem.SetState(new PhantomStateAvailable(phantomSystem));
    }

//DashOrb
    void ToggleToDashOrb(object sender, EventArgs e)
    {
        //if(playerMovement.GetDashDuration()>0) return;
        if(phantomState != PhantomSystem.PhantomState.DASH) return;

        phantom.SetActive(false);
        arrow.SetActive(false);

        dashOrb.transform.position = player.transform.position + Vector3.up;
        dashOrb.transform.rotation = player.transform.rotation;
        dashOrb.SetActive(true);
    }

    void ToggleFromDashOrb(object sender, EventArgs e)
    {
        if(!playerMovement.GetDash()) return;
        if(phantomState != PhantomSystem.PhantomState.DASH) return;

        dashOrbScript.MovePos();
        playerMovement.SetPos(dashOrb.transform.position);

        phantomSystem.SetState(new PhantomStateAvailable(phantomSystem));
    }
}
