using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinalDoorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        // Play the push animation when the button is clicked
        GetComponent<Animator>().SetTrigger("door");
        GetComponent<Animator>().SetBool("door", true);





    }

    private void OnTriggerEnter(Collider other)
    {
        
           SceneManager.LoadScene(4); // Load the specified scene
        
    }
}

