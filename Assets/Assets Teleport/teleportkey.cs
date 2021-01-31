using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportkey : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.gameObject.tag == "Player")
    {
        portalscript.StartTeleport = 1;
    }
    }
}
