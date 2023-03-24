using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Object2Controller : MonoBehaviour
{
    public int sceneIndex;

    private void OnMouseDown()
    {
        sceneIndex = 2;

        // Load Scene 0 additively
        SceneManager.LoadScene(0);
        FindObjectOfType<SceneController>().CheckSceneIndex();

    }

    public int GetSceneIndex()
    {
        return sceneIndex;
    }
}
