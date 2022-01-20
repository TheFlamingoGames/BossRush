using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] PhantomSystem.PhantomState appearOnStateStart = PhantomSystem.PhantomState.NULL;
    [SerializeField] PhantomSystem.PhantomState disappearOnStateEnd = PhantomSystem.PhantomState.NULL;

    [SerializeField] CharacterController controller;

    Animator animator;
    public Vector3 velocity;

    void Awake()
    {
        if (appearOnStateStart != PhantomSystem.PhantomState.NULL) PhantomSystem.OnStateStart += Appear;
        if (disappearOnStateEnd != PhantomSystem.PhantomState.NULL) PhantomSystem.OnStateEnd += Disappear;
    }

    void Start()
    {
        if(controller is null)
            controller = gameObject.GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        velocity = controller.velocity;
        velocity.y = 0;
        animator.SetFloat("Speed", velocity.magnitude);
    }

    void Appear(object sender, PhantomSystem.OnStateStartArgs e)
    {
        Debug.Log(gameObject.name + " has appeared " + e.state.GetType());
    }

    void Disappear(object sender, PhantomSystem.OnStateEndArgs e)
    {
        Debug.Log(gameObject.name + " has disappeared " + e.state.GetType());
    }
}
