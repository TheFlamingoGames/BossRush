using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocusPoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float time = 5f;

    [Space]
    [Header("Looking around")]
    [SerializeField] float radius = 50f;
    Vector3 direction;

    CharacterInput characterInput;
    Vector2 input;
    void Awake()
    {
        characterInput = new CharacterInput();
        characterInput.CameraMovement.LookAround.performed += ctx => input = ctx.ReadValue<Vector2>();
        characterInput.CameraMovement.LookAround.canceled += ctx => input = Vector2.zero;
    }
    void OnEnable()
    {
        characterInput.CameraMovement.Enable();
    }
    void OnDisable()
    {
        characterInput.CameraMovement.Disable();
    }
    private void Start()
    {
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Vector3 lookAt = Vector3.zero;

        lookAt = player.transform.position;
        lookAt.x += direction.normalized.x * radius;
        lookAt.z += direction.normalized.z * radius;

        transform.position = Vector3.Lerp(transform.position, lookAt, time);
    }

    void GetInput() 
    {
        direction = new Vector3(input.x + input.y,0,-input.x + input.y);
    }
}
