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

    void FixedUpdate()
    {
        GetInput();
        Gravity();
        Move();
        playerBody.Move();
    }
    void GetInput()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");
        direction = direction.normalized; 
    }
    private void Gravity() 
    {
        if (gravity.IsGrounded() && velocity.y < 0) 
        {
            velocity.y = -2f;
        }
        velocity.y += Physics.gravity.y * gravityScale*Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Move()
    {
        if (direction.magnitude <= 0) return;

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.transform.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
    }
    public float GetSpeed()
    {
        return moveSpeed;
    }
}
