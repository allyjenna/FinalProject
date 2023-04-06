using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Object2Controller : MonoBehaviour
{
    public static int sceneIndex;

    private void OnMouseDown()
    {
        Debug.Log("Object2Controller: On mouse called");

        // Load Scene 0 additively
        SceneManager.LoadScene(0);
        Debug.Log("Object2Controller: Scene set to 0");
        sceneIndex = 2;
        Debug.Log("Object2Controller: index is: " + sceneIndex);

        // Call CheckSceneIndex method
        RunCheckSceneIndex();
    }

    public int GetSceneIndex()
    {
        return sceneIndex;
    }

    private void RunCheckSceneIndex()
    {
        // Find SceneController object and call CheckSceneIndex method
        SceneController sceneController = FindObjectOfType<SceneController>();
        if (sceneController != null)
        {
            sceneController.CheckSceneIndex();
        }
        else
        {
            Debug.Log("Object2Controller: SceneController not found!");
        }
    }
}
