using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassDoorController : MonoBehaviour
{

    public GameObject doormoveClass;
    public GameObject doorBlock;
    public GameObject targetCollider;

    // Start is called before the first frame update
    void Start()
    {
        doormoveClass.SetActive(false);
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
            doormoveClass.SetActive(true); // Activate the door game object
            doorBlock.SetActive(true); 
        }
    }
}
