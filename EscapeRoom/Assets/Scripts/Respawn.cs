using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Respawn : MonoBehaviour
{
    public GameObject boundary1;
    public GameObject boundary2;
    public GameObject boundary3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == boundary1)
        {
            SceneManager.LoadScene(1);
        }
        else if (other.gameObject == boundary2)
        {
            SceneManager.LoadScene(2);
        }
        else if ((other.gameObject == boundary3))
        {
            SceneManager.LoadScene(3);
        }

    }
}
