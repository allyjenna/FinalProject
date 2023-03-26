using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCollider : MonoBehaviour
{
    [SerializeField] private GameObject rope1;
    [SerializeField] private GameObject rope2;
    [SerializeField] private GameObject rope3;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == rope1 || collision.gameObject == rope2 || collision.gameObject == rope3)
        {
            Debug.Log("Player collided with rope: " + collision.gameObject.name);
            // Do something when the player collides with a rope
        }
    }
}
