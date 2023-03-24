using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class Button2Controller : MonoBehaviour
{
    [SerializeField] private GameObject rope2;

    public void OnMouseDown()
    {
        int SceneIndex2 = FindObjectOfType<Object2Controller>().GetSceneIndex();

        if (SceneIndex2 == 2)
        {
            // Play the push animation when the button is clicked
            GetComponent<Animator>().SetTrigger("push");
            Debug.Log("Button1Controller: Button pushed, playing push animation");

            // Set the ButtonClicked parameter to true
            GetComponent<Animator>().SetBool("push", true);

            // Destroy the rope1 game object when the button is clicked
            Destroy(rope2);
            Debug.Log("Button2Controller: Rope2 destroyed");
        }
    }
}
