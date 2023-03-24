using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class Button3Controller : MonoBehaviour
{
    [SerializeField] private GameObject rope3;

    public void OnMouseDown()
    {
        int SceneIndex3 = FindObjectOfType<Object2Controller>().GetSceneIndex();

        if (SceneIndex3 == 3)
        {
            // Play the push animation when the button is clicked
            GetComponent<Animator>().SetTrigger("push");
            Debug.Log("Button1Controller: Button pushed, playing push animation");

            // Set the ButtonClicked parameter to true
            GetComponent<Animator>().SetBool("push", true);

            // Destroy the rope1 game object when the button is clicked
            Destroy(rope3);
            Debug.Log("Button3Controller: Rope3 destroyed");
        }
    }
}
