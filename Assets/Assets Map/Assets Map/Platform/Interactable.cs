using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRang;
    public KeyCode interactKey1;
    public KeyCode interactKey2;
    public UnityEvent interactAction;

    void Update()
    {
        if (isInRang)
        {
            if (Input.GetKeyDown(interactKey1) || Input.GetKeyDown(interactKey2))
            {
                interactAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dino1") || collision.gameObject.CompareTag("Dino2"))
        {
            isInRang = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dino1") || collision.gameObject.CompareTag("Dino2"))
        {
            isInRang = false;
        }
    }
}
