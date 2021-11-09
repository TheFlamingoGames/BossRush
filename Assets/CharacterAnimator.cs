using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    Animator animator;
    public Vector3 velocity;
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
}
