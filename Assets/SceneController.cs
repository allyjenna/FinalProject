using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject questionMark1;
    public GameObject questionMark2;
    public GameObject questionMark3;
    public GameObject object1Replace;
    public GameObject object2Replace;
    public GameObject object3Replace;

    private void Start()
    {
        // Set initial visibility of objects
        questionMark1.SetActive(true);
        questionMark2.SetActive(true);
        questionMark3.SetActive(true);
        object1Replace.SetActive(false);
        object2Replace.SetActive(false);
        object3Replace.SetActive(false);
        CheckSceneIndex();
    }


    public void CheckSceneIndex()
    {
        //// Check the current scene index and perform necessary actions
        //Debug.Log("Finding Object1Controller...");
        //Object1Controller object1 = FindObjectOfType<Object1Controller>();
        //if (object1 != null)
        //{
        //    int SceneIndex11 = object1.GetSceneIndex();
        //    Debug.Log("currentSceneIndex1: " + SceneIndex11);
        //}
        //else
        //{
        //    Debug.Log("Object1Controller not found!");
        //}

        //Debug.Log("Finding Object2Controller...");
        //Object2Controller object2 = FindObjectOfType<Object2Controller>();
        //if (object2 != null)
        //{
        //    int SceneIndex22 = object2.GetSceneIndex();
        //    Debug.Log("currentSceneIndex2: " + SceneIndex22);
        //}
        //else
        //{
        //    Debug.Log("Object2Controller not found!");
        //}

        //Debug.Log("Finding Object3Controller...");
        //Object3Controller object3 = FindObjectOfType<Object3Controller>();
        //if (object3 != null)
        //{
        //    int SceneIndex33 = object3.GetSceneIndex();
        //    Debug.Log("currentSceneIndex3: " + SceneIndex33);
        //}
        //else
        //{
        //    Debug.Log("Object3Controller not found!");
        //}

        int SceneIndex1 = Object1Controller.sceneIndex;
        Debug.Log("currentSceneIndex: " + SceneIndex1);
        int SceneIndex2 = Object2Controller.sceneIndex;
        Debug.Log("currentSceneIndex: " + SceneIndex2);
        int SceneIndex3 = Object3Controller.sceneIndex;
        Debug.Log("currentSceneIndex: " + SceneIndex3);

        if (SceneIndex1 == 1) // loaded from Scene 1
        {
            questionMark1.SetActive(false); // hide QuestionMark1
            object1Replace.SetActive(true); // show Object1Replace

            Debug.Log("Showing Object1Replace");
        }
        else if (SceneIndex2 == 2) // loaded from Scene 2
        {
            questionMark1.SetActive(false); // hide QuestionMark1
            questionMark2.SetActive(false); // hide 
            object1Replace.SetActive(true); // show Object1Replace
            object2Replace.SetActive(true); // show 
        }
        else if (SceneIndex3 == 3) // loaded from Scene 3
        {
            questionMark1.SetActive(false); // hide QuestionMark1
            questionMark2.SetActive(false); // hide 
            questionMark3.SetActive(false); // hide 
            object1Replace.SetActive(true); // show Object1Replace
            object2Replace.SetActive(true); // show 
            object3Replace.SetActive(true); // show 
        }
    }
}
