using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public float speed;
    public Transform startPos;
    public bool is_activate;

    Vector3 nextPos;


    public void Move()
    {
        if (!is_activate)
            is_activate = true;
        else
            is_activate = false;
    }

    void Start()
    {
        nextPos = startPos.position;
    }

    void FixedUpdate()
    {
        if (is_activate)
            nextPos = pos2.position;
        else
            nextPos = pos1.position;
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}