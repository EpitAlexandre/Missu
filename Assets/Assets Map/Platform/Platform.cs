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

    void Start()
    {
        nextPos = startPos.position;
    }

    void FixedUpdate()
    {
        if (transform.position.x == pos1.position.x)
        {
            nextPos = pos2.position;
        }
        if (transform.position.x == pos2.position.x)
        {
            nextPos = pos1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

}