using UnityEngine;

public class LockCamera : MonoBehaviour
{
    [SerializeField] private Camera lockCamera;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform target;
    [SerializeField] private Canvas lockCanvas;

    private void Start()
    {
        // Disable the LockCamera component and the lock canvas at the start of the game
        lockCamera.enabled = false;
        lockCanvas.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Entered trigger zone");
            mainCamera.enabled = false;
            lockCamera.enabled = true;
            lockCanvas.enabled = true;

            lockCamera.transform.position = target.position;
            lockCamera.transform.rotation = target.rotation;
       }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Exited trigger zone");
            lockCamera.enabled = false;
            mainCamera.enabled = true;
            lockCanvas.enabled = false;
        }
    }
}
