using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] Transform groundCheck;
    [SerializeField] float radius = 0.4f;
    [SerializeField] LayerMask groundLayer;
    [Space]
    [Header("Gizmos")]
    [SerializeField] bool isGizmosOn;
    [SerializeField] Color sphereColor;

    bool isGrounded;

    private void Update()
    {
        if (isGizmosOn)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(groundCheck.position, radius);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, radius, groundLayer);

    }

    public bool IsGrounded() 
    {
        return isGrounded;
    }
}
