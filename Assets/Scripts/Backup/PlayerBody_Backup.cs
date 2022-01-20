using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody_Backup : MonoBehaviour
{
    List<Vector3> phantomPoz = new List<Vector3>();
    List<Quaternion> phantomDir = new List<Quaternion>();
    [SerializeField] Transform player;

    [SerializeField] int pozListCount = 5;
    [SerializeField] int pozCountMargin = 2;

    public void Move()
    {
        phantomPoz.Add(player.position);
        phantomDir.Add(player.rotation);

        if(phantomPoz.Count >= pozListCount)
        {
            transform.position = phantomPoz[0];
            phantomPoz.RemoveAt(0);

            transform.rotation = phantomDir[0];
            phantomDir.RemoveAt(0);
        }

        if (pozCountMargin < phantomPoz.Count - pozListCount) 
        {
            phantomPoz.RemoveAt(0);
            phantomDir.RemoveAt(0);
        }
    }
}
