using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DashOrb : MonoBehaviour
{
    //Orb
    [SerializeField] float spawnDistance = 1f;
    [SerializeField] float maxDistance = 5f;
    [SerializeField] float force=0.2f;
    [SerializeField] [Range(0f,1f)] float treshold = 0.5f;
    [SerializeField] Transform orb;
    [SerializeField] Transform player;
    float distance;
    [SerializeField] LayerMask collisionLayers;

    //States
    PhantomSystem.PhantomState phantomState => PhantomSystem.GetPhantomState();

    void Awake()
    {
        PhantomSystem.OnStateStart += ResetDistance;
    }

    void ResetDistance(object sender, EventArgs e)
    {
        if(phantomState != PhantomSystem.PhantomState.DASH) return;
        Vector3 newPos = transform.position + transform.TransformDirection(Vector3.forward)*spawnDistance;
        
        orb.position = newPos;
        orb.rotation = transform.rotation;

        distance = spawnDistance;
    }
    public void MovePos()
    {
        Vector3 newPos = orb.position; 
        newPos.y = player.position.y;
        transform.position = newPos;
        orb.position = transform.position;
    }

    void FixedUpdate()
    {
        transform.rotation = player.rotation;
        Ray orbProjectory = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        RaycastHit hit;

        Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward*distance),Color.red);

        if(Physics.Raycast(orbProjectory, out hit, distance,collisionLayers))
        {
            distance = hit.distance;
        }
        else if(distance < maxDistance)
        {
            distance += force; 
        }
        orb.position = transform.position + orb.forward * (distance-treshold); 
    }
}
