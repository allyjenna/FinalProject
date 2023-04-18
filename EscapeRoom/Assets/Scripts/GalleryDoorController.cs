using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryDoorController : MonoBehaviour
{
    public GameObject doorBlock;
    public GameObject galleryDoor;
    public GameObject targetCollider;
    public Canvas galleryCanvas;

    private bool canvasEnabled;

    // Start is called before the first frame update
    void Start()
    {
        doorBlock.SetActive(false);
        galleryCanvas.enabled = false;
        canvasEnabled = false;
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        if (canvasEnabled && Input.GetMouseButtonDown(0))
        {
            galleryCanvas.enabled = false; // disable the canvas
            canvasEnabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetCollider)
        {
            Debug.Log("COLLISION");
            galleryDoor.SetActive(true); // Activate the door game object
            doorBlock.SetActive(true);
            galleryCanvas.enabled = true;
            canvasEnabled = true;
        }
    }
}
