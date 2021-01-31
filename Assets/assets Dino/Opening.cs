using UnityEngine;

public class Opening : MonoBehaviour
{
    private PlayerMovement controller;
    public Collider2D door;
    private Animator animator;

    private presureplate pressur;
    public GameObject pressureplate;
    public GameObject dooor;

    public bool toopen = false;
    
    /*void OnTriggerEnter2D(Collider2D other)
    {
        controller = other.GetComponent<PlayerMovement>();

        //if (other.name == "dino")
        if (Input.GetKeyDown(KeyCode.E))
            other.enabled = !other.enabled;
    }
*/

    void Start()
    {
        pressur = pressureplate.GetComponent<presureplate>();
    }

    void Update()
    {
        Debug.Log(pressur.toopen);
        if (pressur.toopen == true)
            doorOpen();
        else
            doorClose();
    }

    public void doorOpen()
    {
        dooor.SetActive(false);
    }
    public void doorClose()
    {
        dooor.SetActive(true);
    }
}
