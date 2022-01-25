using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Arrow : MonoBehaviour
{

    public enum ArrowState
    {
        PREPARED,
        SHOT,
        RETURN
    }
    public ArrowState arrowState = ArrowState.PREPARED;

    [SerializeField] Transform player;

    [SerializeField] float force = 5f;
    [SerializeField] float lerpTime = 5f;
    Rigidbody rigid;

    [SerializeField] LayerMask collisionLayers;

    //States
    PhantomSystem.PhantomState phantomState => PhantomSystem.GetPhantomState();

    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        rigid.Sleep();
    }

    void FixedUpdate()
    {
        if(arrowState != Arrow.ArrowState.RETURN) return;
        Vector3 newPos = player.position;
        newPos.y+=1;
        transform.position = Vector3.Lerp(transform.position,newPos,lerpTime);
        transform.LookAt(newPos);
    }


    public void Shoot()
    {
        if(arrowState != Arrow.ArrowState.PREPARED) return;
        arrowState = ArrowState.SHOT;
        rigid.WakeUp();
        rigid.velocity = Vector3.zero;
        rigid.AddForce(transform.TransformDirection(Vector3.forward).normalized*force);
    }

    public ArrowState GetArrowState()
    {
        return arrowState;
    }

    public void SetArrowState(ArrowState newArrowState)
    {
        arrowState = newArrowState;
    }

    public void Return()
    {
        arrowState = ArrowState.RETURN;
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
        rigid.Sleep();
    }

    private void OnTriggerEnter(Collider col)
    {
        if(arrowState != Arrow.ArrowState.SHOT) return;
        if((collisionLayers.value & 1<<col.gameObject.layer) == 1<<col.gameObject.layer)
        {
            Return();
        }
    }

}
