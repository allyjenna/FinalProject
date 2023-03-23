using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1Controller : MonoBehaviour
{
    [SerializeField] private GameObject rope1;

    public SwitchController switchController;

    public void Start()
    {
        Debug.Log("Start method called");
        // Find the SwitchController component and get a reference to it
        switchController = FindObjectOfType<SwitchController>();

        // Add a listener to the onSwitchDown event, if switchController is not null
        if (switchController != null)
        {
            switchController.onSwitchDown.AddListener(OnSwitchDown);
        }
    }




    private void OnSwitchDown()
    {
        // Destroy the rope1 game object when the switch is down and the button is clicked
        Destroy(rope1);
    }
}

