using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    List<Vector3> playerPoz = new List<Vector3>();
    List<Quaternion> playerDir = new List<Quaternion>();
    [SerializeField] Transform player;

    [SerializeField] int pozListCount = 5;
    [SerializeField] int pozCountMargin = 2;

    [SerializeField] float moveSpeed = 10f;

    public void Move()
    {
        playerPoz.Add(player.position);
        playerDir.Add(player.rotation);

        if(playerPoz.Count >= pozListCount)
        {
            transform.position = Vector3.MoveTowards(transform.position,playerPoz[0],moveSpeed*Time.deltaTime);
            playerPoz.RemoveAt(0);

            transform.rotation = playerDir[0];
            playerDir.RemoveAt(0);
        }

        if (pozCountMargin < playerPoz.Count - pozListCount) 
        {
            playerPoz.RemoveAt(0);
            playerDir.RemoveAt(0);
        }
    }
}
