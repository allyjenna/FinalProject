using UnityEngine;

public class DestroyFlashlight : MonoBehaviour
{
    public GameObject flashlightObject;
    public bool isFlashlightDestroyed = false;
    public Camera playerCamera;
    public float maxDistance = 5f;

    private void Update()
    {
        // cast a ray from the center of the screen
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            // check if the ray hit the flashlight
            if (hit.collider.gameObject == flashlightObject)
            {
                // destroy the flashlight and set the flag to true
                Destroy(flashlightObject);
                isFlashlightDestroyed = true;
            }
        }
    }
}
