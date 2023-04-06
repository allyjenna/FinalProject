using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button3Controller : MonoBehaviour
{
    [SerializeField] private GameObject rope3;

    public void OnMouseDown()
    {
        SceneController sceneController = FindObjectOfType<SceneController>();

        if (sceneController != null)
        {
            int sceneIndex3 = Object2Controller.sceneIndex;

            if (sceneIndex3 == 2)
            {
                // Play the push animation when the button is clicked
                GetComponent<Animator>().SetTrigger("push");
                Debug.Log("Button3Controller: Button pushed, playing push animation");

                // Set the ButtonClicked parameter to true
                GetComponent<Animator>().SetBool("push", true);

                // Destroy the rope2 game object when the button is clicked
                Destroy(rope3);
                Debug.Log("Button2Controller: Rope3 destroyed");

            }
        }
        else
        {
            Debug.Log("Button3Controller: SceneController not found!");
        }
    }
}
