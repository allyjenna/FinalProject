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
    public GameObject door;
    public GameObject player;
    public Vector3 targetPosition1;
    public Vector3 targetPosition2;
    public Vector3 targetPosition3;



    private void Start()
    {
        // Set initial visibility of objects
        questionMark1.SetActive(true);
        questionMark2.SetActive(true);
        questionMark3.SetActive(true);
        object1Replace.SetActive(false);
        object2Replace.SetActive(false);
        object3Replace.SetActive(false);
        //door.SetActive(false);
        door.SetActive(true);

        CheckSceneIndex();
    }


    public void CheckSceneIndex()
    {
        

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
            player.transform.position = targetPosition1;

            Debug.Log("Showing Object1Replace");
        }
        if (SceneIndex2 == 2) // loaded from Scene 2
        {
            questionMark1.SetActive(false); // hide QuestionMark1
            questionMark2.SetActive(false); // hide 
            object1Replace.SetActive(true); // show Object1Replace
            object2Replace.SetActive(true); // show
            player.transform.position = targetPosition2;

            Debug.Log("Showing Object2Replace");

        }
        if (SceneIndex3 == 3) // loaded from Scene 3
        {
            questionMark1.SetActive(false); // hide QuestionMark1
            questionMark2.SetActive(false); // hide 
            questionMark3.SetActive(false); // hide 
            object1Replace.SetActive(true); // show Object1Replace
            object2Replace.SetActive(true); // show 
            object3Replace.SetActive(true); // show
            door.SetActive(true);
            player.transform.position = targetPosition3;

            Debug.Log("Showing Object3Replace");

        }
    }
}
