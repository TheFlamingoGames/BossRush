using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] float spawnDistance = 1f;
    [SerializeField] float maxDistance = 500f;
    [SerializeField] Transform arrow;
    Arrow arrowScript;

    [SerializeField] Transform player;

    float distance;

    //States
    StateMachine phantomSystem => PhantomSystem.GetState().statemachine;
    PhantomSystem.PhantomState phantomState => PhantomSystem.GetPhantomState();

    void Awake()
    {
        arrowScript = arrow.GetComponent<Arrow>();
    }

    void Start()
    {
        PhantomSystem.OnStateStart += ResetDistance;
        InputManager.instance.OnArrowReleased += CancelArrow;
        InputManager.instance.OnParryReleased += ShootArrow;
    }

    void ResetDistance(object sender, EventArgs e)
    {
        if(phantomState != PhantomSystem.PhantomState.ARROW) return;

        arrowScript.SetArrowState(Arrow.ArrowState.PREPARED);
        transform.position = player.position;
        Vector3 newPos = transform.position + transform.TransformDirection(Vector3.forward)*spawnDistance;
        newPos.y += 1;
        arrow.position = newPos;
        arrow.rotation = transform.rotation;

        distance = 0;
    }

    void CancelArrow(object sender, EventArgs e)
    {
        if (phantomState != PhantomSystem.PhantomState.ARROW) return;
        if(arrowScript.GetArrowState() != Arrow.ArrowState.PREPARED) return;

        phantomSystem.SetState(new PhantomStateAvailable(phantomSystem));
    }

    void ShootArrow(object sender, EventArgs e)
    {
        if (phantomState != PhantomSystem.PhantomState.ARROW) return;
        if(arrowScript.GetArrowState() != Arrow.ArrowState.PREPARED) return;

        arrowScript.Shoot();
    }

    void FixedUpdate()
    {
        RotateTransform();
        CheckArrowDistance();
        CheckArrowReturn();
    }

    //aiming
    void RotateTransform()
    {
        if (phantomState != PhantomSystem.PhantomState.ARROW) return;
        if (arrowScript.GetArrowState() != Arrow.ArrowState.PREPARED) return;
        transform.rotation = player.rotation;
    }

    //Arrow flies away
    void CheckArrowDistance()
    {
        if (arrowScript.GetArrowState() != Arrow.ArrowState.SHOT) return;
        Vector3 playerPos = player.position+Vector3.up;
        distance = (arrow.position-playerPos).magnitude;
        if (Math.Abs(distance)>maxDistance)
        {
            arrowScript.Return();
            arrowScript.SetArrowState(Arrow.ArrowState.RETURN);
        }
    }

    //Arrow flies back
    void CheckArrowReturn()
    {
        if (arrowScript.GetArrowState() != Arrow.ArrowState.RETURN) return;
        Vector3 playerPos = player.position+Vector3.up;
        distance = (arrow.position-playerPos).magnitude;
        if (Math.Abs(distance)<spawnDistance)
        {
            phantomSystem.SetState(new PhantomStateAvailable(phantomSystem));
        }
    }
}
