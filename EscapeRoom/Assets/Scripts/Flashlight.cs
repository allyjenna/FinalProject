using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlightObject;
    public bool isFlashlightDestroyed = false;
    public Camera playerCamera;
    public float maxDistance = 5f;

    [SerializeField] GameObject Light;
    [SerializeField] Material Mat;
    [SerializeField] Light SpotLight;
    public Transform target;
    private bool LightActive = false;
    private Color originalAmbientColor;
    private float originalAmbientIntensity;
    public Canvas flashlightCanvas;

    private void Start()
    {
        Light.SetActive(false);
        originalAmbientColor = RenderSettings.ambientLight;
        originalAmbientIntensity = RenderSettings.ambientIntensity;
        flashlightCanvas.enabled = false;
    }

    private void Update()
    {
        if (isFlashlightDestroyed == false)
        {
            // cast a ray from the center of the screen
            Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out RaycastHit hit, maxDistance))
            {
                // check if the ray hit the flashlight
                if (hit.collider.gameObject == flashlightObject)
                {
                    // destroy the flashlight and set the flag to true
                    Destroy(flashlightObject);
                    isFlashlightDestroyed = true;
                    flashlightCanvas.enabled = true;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (LightActive == false)
                {
                    Light.SetActive(true);
                    LightActive = true;
                    RenderSettings.ambientLight = new Color(.8f, 0.05f, 2f, 5f);
                    RenderSettings.ambientIntensity = 0.01f;
                }
                else
                {
                    Light.SetActive(false);
                    LightActive = false;
                    RenderSettings.ambientLight = originalAmbientColor;
                    RenderSettings.ambientIntensity = originalAmbientIntensity;
                    Mat.SetVector("MyLightPosition", Vector3.zero);
                    Mat.SetVector("MyLightDirection", Vector3.zero);
                    Mat.SetFloat("MyLightAngle", 0f);
                }
            }

            if (LightActive && target != null)
            {
                if (Physics.Raycast(SpotLight.transform.position, target.position - SpotLight.transform.position, out RaycastHit hit))
                {
                    if (hit.transform == target)
                    {
                        Mat.SetVector("MyLightPosition", SpotLight.transform.position);
                        Mat.SetVector("MyLightDirection", -SpotLight.transform.forward);
                        Mat.SetFloat("MyLightAngle", SpotLight.spotAngle);
                    }
                    else
                    {
                        Light.SetActive(false);
                        LightActive = false;
                        Mat.SetVector("MyLightPosition", Vector3.zero);
                        Mat.SetVector("MyLightDirection", Vector3.zero);
                        Mat.SetFloat("MyLightAngle", 0f);
                    }
                }
            }

            // check if the flashlight canvas is enabled and if the left mouse button is clicked
            if (flashlightCanvas.enabled && Input.GetMouseButtonDown(0))
            {
                flashlightCanvas.enabled = false; // disable the canvas
            }
        }
    }
}
