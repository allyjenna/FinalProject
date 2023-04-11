using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
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
        GetComponent<Animator>().SetTrigger("box");

        // Set the ButtonClicked parameter to true
        GetComponent<Animator>().SetBool("box", true);


    }
}
