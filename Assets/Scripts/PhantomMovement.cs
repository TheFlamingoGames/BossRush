using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomMovement : MonoBehaviour
{
    //Generic
    Camera mainCamera;
    CharacterController controller;

    //Input
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

    void Start()
    {
        mainCamera = Camera.main;
        controller = gameObject.GetComponent<CharacterController>();
        gravity = gameObject.GetComponent<GroundCheck>();
    }
    private void Update()
    {
        GetInput();
    }
    void FixedUpdate()
    {
        Gravity();
        Move();
        playerBody.Move();
    }
    void GetInput()
    {
        //direction.x = Mathf.Abs(Input.GetAxisRaw("D Pad Horizontal")) > 0 ? Input.GetAxisRaw("D Pad Horizontal") : Input.GetAxisRaw("Horizontal");
        //direction.z = Mathf.Abs(Input.GetAxisRaw("D Pad Vertical")) > 0 ? Input.GetAxisRaw("D Pad Vertical") : Input.GetAxisRaw("Vertical");
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");


        if (dashDurationDelta <= 0)
        {
            if (Input.GetButtonDown("Jump"))
            {
                dashDelta = dashTime;
                dashDurationDelta = dashDuration;
            }
        }
        else 
        {
            dashDelta -= Time.deltaTime;
            dashDurationDelta -= Time.deltaTime;
        }
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
