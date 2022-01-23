using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BodyMovement : MonoBehaviour
{
    //Generic
    Camera mainCamera;
    CharacterController controller;
    StateMachine phantomSystem => PhantomSystem.GetState().statemachine;

    //Input
    Vector2 input => InputManager.instance.GetLStickInput();
    Vector3 direction;

    //Movement
    [Space]
    [Header("Movement")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    //Dash
    [Space]
    [Header("Dash")]
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashTime = 0.5f;
    [SerializeField] float dashDuration = 1f;
    float dashDelta;
    float dashDurationDelta;
    bool dash;
    bool dashHeldDown;

    //Gravity
    [Space]
    [Header("Gravity")]
    GroundCheck groundCheck;
    Vector3 velocity;
    [SerializeField] float gravityScale = 1f;

    //Follow Point
    [Space]
    [Header("FollowPoint")]
    [SerializeField] Transform followPoint;
    [SerializeField] float distance=1f;

    PhantomSystem.PhantomState phantomState => PhantomSystem.GetPhantomState();

    void OnDashReleased(object sender, EventArgs e)
    {
        dash = false;
    }

    void OnDash(object sender, EventArgs e)
    {
        if (dashDurationDelta > 0) return; //If cooldown allows it

        if(phantomState == PhantomSystem.PhantomState.AVAILABLE) 
        {
            DashTeleport();
        }
        else
        {
            DashRoll(); 
        }
    }
    void DashTeleport()
    {
        phantomSystem.SetState(new PhantomStateDash(phantomSystem));
        dash = true;
    }
    void DashRoll()
    {
        dashDelta = dashTime;
        dashDurationDelta = dashDuration;
    }

    void Start()
    {
        InputManager.instance.OnDashPressed += OnDash;
        InputManager.instance.OnDashReleased += OnDashReleased;

        mainCamera = Camera.main;
        controller = gameObject.GetComponent<CharacterController>();
        groundCheck = gameObject.GetComponent<GroundCheck>();
    }

    private void Update()
    {
        direction = new Vector3(input.x, 0, input.y);
        dashDelta -= Time.deltaTime;
        dashDurationDelta -= Time.deltaTime;
    }
    void FixedUpdate()
    {
        Gravity();
        Move();
    }

    #region Movement
    private void Gravity() 
    {
        if (dashDelta > 0) return;

        if (groundCheck.IsGrounded() && velocity.y < 0) 
        {
            velocity.y = -2f;
        }
        velocity.y += Physics.gravity.y * gravityScale * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Move()
    {
        if (dashDelta > 0)
        {
            MoveDash();
        }
        else 
        {
            MoveRun();
        }
        followPoint.localPosition = new Vector3(0,0,Mathf.Clamp(controller.velocity.magnitude, 0, distance));
    }

    private void MoveRun() 
    {
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.transform.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        if (direction.magnitude > 0) transform.rotation = Quaternion.Euler(0f, angle, 0f);
        Vector3 moveDir = !dash? Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward : Vector3.zero;

        
        controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime * direction.magnitude);
    }

    private void MoveDash()
    {
        controller.Move(transform.forward * dashSpeed * Time.deltaTime);
    }
    #endregion

    #region getters
    public float GetDashDuration()
    {
        return dashDurationDelta;
    }
    #endregion

    public void SetPos( Vector3 newPos)
    {
        transform.position = newPos;
    }
}
