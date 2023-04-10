
using UnityEngine;

public class BeakerController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnMouseDown()
    {
       
         // Play the push animation when the button is clicked
         GetComponent<Animator>().SetTrigger("Spill");

        // Set the ButtonClicked parameter to true
        GetComponent<Animator>().SetBool("Spill", true);
    }
 
}
