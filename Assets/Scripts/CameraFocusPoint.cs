using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocusPoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float time = 5f;
    [SerializeField] bool slerpOrLerp = false;

    private void Start()
    {
    }
    private void FixedUpdate()
    {
        if (slerpOrLerp)
        {
            transform.position = Vector3.Slerp(transform.position, player.transform.position, time);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, time);
        }
    }
}
