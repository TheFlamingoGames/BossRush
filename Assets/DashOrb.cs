using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DashOrb : MonoBehaviour
{
    [SerializeField] float maxDistance = 5f;
    [SerializeField] float force=0.2f;
    float distance;

    Rigidbody rigid;
    Vector3 originPos;

    PhantomSystem.PhantomState phantomState => PhantomSystem.GetPhantomState();
    Vector2 input => InputManager.instance.GetLStickInput().normalized;

    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        PhantomSystem.OnStateStart += ResetDistance;
    }

    void ResetDistance(object sender, EventArgs e)
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
