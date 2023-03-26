using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button2Controller : MonoBehaviour
{
    [SerializeField] private GameObject rope2;

    public void OnMouseDown()
    {
        SceneController sceneController = FindObjectOfType<SceneController>();

        if (sceneController != null)
        {
            int sceneIndex2 = Object1Controller.sceneIndex;

            if (sceneIndex2 == 1)
            {
                // Play the push animation when the button is clicked
                GetComponent<Animator>().SetTrigger("push");
                Debug.Log("Button2Controller: Button pushed, playing push animation");

                // Set the ButtonClicked parameter to true
                GetComponent<Animator>().SetBool("push", true);

                // Destroy the rope2 game object when the button is clicked
                Destroy(rope2);
                Debug.Log("Button2Controller: Rope2 destroyed");
            }
        }
        else
        {
            Debug.Log("Button2Controller: SceneController not found!");
        }
    }
}
