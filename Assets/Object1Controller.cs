using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Object1Controller : MonoBehaviour
{
    public int sceneIndex;

    private void OnMouseDown()
    {
        Debug.Log("Object1Controller: On mouse called");

        sceneIndex = 1;
        Debug.Log("Object1Controller: index is: " + sceneIndex);

        // Load Scene 0 additively
        SceneManager.LoadScene(0);
        Debug.Log("Object1Controller: Scene set to 0");

  
        FindObjectOfType<SceneController>().CheckSceneIndex();


    }

    public int GetSceneIndex()
    {
        return sceneIndex;
    }
}
