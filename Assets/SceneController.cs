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
    }

    public void CheckSceneIndex()
    {
        int SceneIndex1 = FindObjectOfType<Object1Controller>().GetSceneIndex();
        Debug.Log("currentSceneIndex: " + SceneIndex1);
        int SceneIndex2 = FindObjectOfType<Object2Controller>().GetSceneIndex();
        Debug.Log("currentSceneIndex: " + SceneIndex2);
        int SceneIndex3 = FindObjectOfType<Object3Controller>().GetSceneIndex();
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
