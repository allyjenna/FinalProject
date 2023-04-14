using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    public GameObject portalObject;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == portalObject)
        {
            SceneManager.LoadScene(4);
        }
    }
}
