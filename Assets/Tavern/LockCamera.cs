using UnityEngine;

public class LockCamera : MonoBehaviour
{
    [SerializeField] private Camera lockCamera;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform target;

    private void Start()
    {
        // Disable the LockCamera component at the start of the game
        lockCamera.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mainCamera.enabled = false;
            lockCamera.enabled = true;
            lockCamera.transform.position = target.position;
            lockCamera.transform.rotation = target.rotation;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lockCamera.enabled = false;
            mainCamera.enabled = true;
        }
    }
}
