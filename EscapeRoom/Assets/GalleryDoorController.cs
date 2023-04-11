
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryDoorController : MonoBehaviour
{
    public GameObject doorBlock;
    public GameObject galleryDoor;
    public GameObject targetCollider;

    // Start is called before the first frame update
    void Start()
    {
        galleryDoor.SetActive(false);
        doorBlock.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetCollider)
        {
            Debug.Log("COLLISION");
            galleryDoor.SetActive(true); // Activate the door game object
            doorBlock.SetActive(true); 
        }
    }
}
