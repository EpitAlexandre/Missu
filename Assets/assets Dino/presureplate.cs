using UnityEngine;

public class presureplate : MonoBehaviour
{
    private Collider2D player;
    public Collider2D pressureplate;

    public bool toopen = false;
    public GameObject dino;
    

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "dino")
            toopen = true;
        
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "dino")
            toopen = false;
        
    }
    /*void Update ()
    {
        toopen = false;
    }*/

}
