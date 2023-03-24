using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Object3Controller : MonoBehaviour
{
    public int sceneIndex;

    private void OnMouseDown()
    {
        sceneIndex = 3;

        // Load Scene 0 additively
        SceneManager.LoadScene(0);
        FindObjectOfType<SceneController>().CheckSceneIndex();

    }

    public int GetSceneIndex()
    {
        return sceneIndex;
    }
}
