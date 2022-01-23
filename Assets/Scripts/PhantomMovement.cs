using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PhantomMovement : MonoBehaviour
{
    CharacterController controller;
    Vector3 velocity;

    [SerializeField] Transform followPoint;
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float treshold = 0.05f;

    void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        velocity = (followPoint.position-transform.position);
        if(velocity.magnitude<treshold) velocity = Vector3.zero;
        controller.Move(velocity * moveSpeed);
        transform.rotation = followPoint.rotation;
    }
}
