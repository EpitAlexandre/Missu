using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalscript : MonoBehaviour
{
    public GameObject Portal, Player;
    public static int StartTeleport = 0;
    void Start ()
    {

    }

    void update () 
    {

    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player" && portalscript.StartTeleport == 1) 
        {
            portalscript.StartTeleport = 0;
            StartCoroutine (Teleport ());
        }
    }

    IEnumerator Teleport()
    {
        yield return new  WaitForSeconds (1);
        Player.transform.position = new Vector2 (Portal.transform.position.x, Portal.transform.position.y);
    }
}
