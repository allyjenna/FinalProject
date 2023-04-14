using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    private bool isOpen = false;

    public void OpenDoor()
    {
        if (!isOpen)
        {
            StartCoroutine(OpenDoorCoroutine());
        }
    }

    private IEnumerator OpenDoorCoroutine()
    {
        isOpen = true;

        // Wait for a moment before destroying the door
        yield return new WaitForSeconds(1f);

        // Destroy the door object
        Destroy(gameObject);

    }
}
