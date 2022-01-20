using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFocusPoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float time = 5f;

    [Space]
    [Header("Looking around")]
    [SerializeField] Vector3 offset = Vector3.zero;
    [SerializeField] float radius = 50f;
    Vector3 direction;

    

    Vector2 rInput => InputManager.instance.GetRStickInput();
    Vector2 mInput => InputManager.instance.GetMousePos();
    float screenRatio => (float)Screen.height / (float)Screen.width;

    bool isMouseControlEnabled;

    new Camera camera;


    void Awake()
    {
        camera = Camera.main;
    }

    private void  Start()
    {
        InputManager.instance.OnEnableCameraPressed += PrintPressed;
        InputManager.instance.OnEnableCameraReleased += PrintReleased;
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Vector3 lookAt = Vector3.zero;

        lookAt = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y , player.transform.position.z + offset.z);
        lookAt.x += direction.normalized.x * radius;
        lookAt.z += direction.normalized.z * radius;

        transform.position = Vector3.Lerp(transform.position, lookAt, time);
    }

    Vector2 NewMPos()
    {
        //Move the mouse origo into the middle of the screen, then make the values into a circle
        Vector2 newMPos = camera.ScreenToViewportPoint(mInput);
        newMPos = (newMPos/0.5f)-Vector2.one;
        newMPos.x /= screenRatio;
        return newMPos.normalized;   
    }

    void GetInput() 
    {
        Vector2 input = Vector2.zero;

        if(isMouseControlEnabled) input = NewMPos();
        else input = rInput;

        direction = new Vector3(input.x + input.y,0,-input.x + input.y);
    }

    void PrintPressed(object sender, EventArgs e)
    {
        isMouseControlEnabled = true;
    }

    void PrintReleased(object sender, EventArgs e)
    {
        isMouseControlEnabled = false;
    }
}
