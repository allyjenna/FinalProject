using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassDoorController : MonoBehaviour
{
    public GameObject classDoor;
    public GameObject doorBlock;
    public GameObject targetCollider;
    public Canvas classCanvas;

    private bool canvasEnabled;

    // Start is called before the first frame update
    void Start()
    {
        classDoor.SetActive(false);
        doorBlock.SetActive(false);
        classCanvas.enabled = false;
        canvasEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canvasEnabled && Input.GetMouseButtonDown(0))
        {
            classCanvas.enabled = false; // disable the canvas
            canvasEnabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetCollider)
        {
            Debug.Log("COLLISION");
            classDoor.SetActive(true); // Activate the door game object
            doorBlock.SetActive(true);
            classCanvas.enabled = true;
            canvasEnabled = true;
        }
    }
}
