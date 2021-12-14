using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PhantomMovement : MonoBehaviour
{
    //Generic
    Camera mainCamera;
    CharacterController controller;
    CharacterInput characterInput;

    //Input
    Vector2 input;
    Vector3 direction;


    //Movement
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    //Dash
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashTime = 0.5f;
    [SerializeField] float dashDuration = 1f;
    float dashDelta;
    float dashDurationDelta;
    public bool dash => dashDelta > 0;

    //Gravity
    GroundCheck gravity;
    Vector3 velocity;
    [SerializeField] float gravityScale = 1f;

    //PlayerBody
    [SerializeField] PlayerBody playerBody;

    void Awake()
    {
        characterInput = new CharacterInput();
        //Dash
        characterInput.PlayerMovement.Dash.performed += ctx => Dash();

        //Controller Movement
        characterInput.PlayerMovement.Move.performed += ctx => input = ctx.ReadValue<Vector2>();
        characterInput.PlayerMovement.Move.canceled += ctx => input = Vector2.zero;
    }
    
    void OnEnable()
    {
        characterInput.PlayerMovement.Enable();
    }
    void OnDisable()
    {
        characterInput.PlayerMovement.Disable();
    }

    void Start()
    {
        mainCamera = Camera.main;
        controller = gameObject.GetComponent<CharacterController>();
        gravity = gameObject.GetComponent<GroundCheck>();
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
        playerBody.Move();
    }

    void Dash()
    {
        if (dashDurationDelta > 0) return;
        dashDelta = dashTime;
        dashDurationDelta = dashDuration;
    }

    #region Movement
    private void Gravity() 
    {
        if (dash) return;

        if (gravity.IsGrounded() && velocity.y < 0) 
        {
            velocity.y = -2f;
        }
        velocity.y += Physics.gravity.y * gravityScale*Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Move()
    {
        if (dash)
        {
            MoveDash();

        }
        else 
        {
            MoveRun();
        }
    }

    private void MoveRun() 
    {
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.transform.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        if (direction.magnitude > 0) transform.rotation = Quaternion.Euler(0f, angle, 0f);
        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime * direction.magnitude);
    }

    private void MoveDash()
    {
        controller.Move(transform.forward * dashSpeed * Time.deltaTime);
    }
    #endregion

    #region getters
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public float GetDashSpeed()
    {
        return dashSpeed;
    }
    public bool GetDash()
    {
        return dash;
    }
    #endregion
}
