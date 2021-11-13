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
        Vector2 input = new Vector2(
            Input.GetAxisRaw("R Joystick Horizontal"),
            Input.GetAxisRaw("R Joystick Vertical") * -1);

        direction = new Vector3(input.x + input.y,0,-input.x + input.y);
    }
}
