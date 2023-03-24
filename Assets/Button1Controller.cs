using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1Controller : MonoBehaviour
{
    [SerializeField] private GameObject rope1;

    public SwitchController switchController;

    public void Start()
    {
        Debug.Log("Button1Controller: Start method called");
        // Find the SwitchController component and get a reference to it
        switchController = FindObjectOfType<SwitchController>();

        // Add a listener to the onSwitchDown event, if switchController is not null
        if (switchController != null)
        {
            switchController.onSwitchDown.AddListener(OnSwitchDown);
            Debug.Log("Button1Controller: Added listener to onSwitchDown event");
        }
        else
        {
            Debug.Log("Button1Controller: SwitchController not found");
        }
    }

    private void OnSwitchDown()
    {
        // Enable the button when the switch is down
        gameObject.SetActive(true);
        Debug.Log("Button1Controller: Switch is down, button is now active");
    }

    public void OnMouseDown()
    {
        // Play the push animation when the button is clicked
        GetComponent<Animator>().SetTrigger("push");
        Debug.Log("Button1Controller: Button pushed, playing push animation");

        // Set the ButtonClicked parameter to true
        GetComponent<Animator>().SetBool("push", true);

        // Destroy the rope1 game object when the button is clicked
        Destroy(rope1);
        Debug.Log("Button1Controller: Rope1 destroyed");
    }
}
