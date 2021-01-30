using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Opening door;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E))
            door.doorOpen();
        if (Input.GetKeyDown(KeyCode.G))
            door.doorClose();
    }
}
