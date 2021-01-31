using UnityEngine;

public class Opening : MonoBehaviour
{
    private PlayerMovement controller;
    public Collider2D door;
    private Animator animator;

    /*void OnTriggerEnter2D(Collider2D other)
    {
        controller = other.GetComponent<PlayerMovement>();

        //if (other.name == "dino")
        if (Input.GetKeyDown(KeyCode.E))
            other.enabled = !other.enabled;
    }
*/

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void doorOpen()
    {
        animator.SetBool("Open", true);
        gameObject.SetActive(false);
    }
    public void doorClose()
    {
        animator.SetBool("Open", false);
        gameObject.SetActive(true);
    }
}
