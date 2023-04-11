using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSwitch : MonoBehaviour
{ 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Swamp"))
        {
            Debug.Log("Swamp");
            SceneManager.LoadScene(1);
        }
        else if (other.CompareTag("Crypt"))
        {
            Debug.Log("Crypt");
            SceneManager.LoadScene(2);
        }
        else if (other.CompareTag("Sand"))
        {
            Debug.Log("Sand");
            SceneManager.LoadScene(3);
        }

       
    }
}
