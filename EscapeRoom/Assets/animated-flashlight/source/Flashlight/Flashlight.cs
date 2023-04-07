using UnityEngine;

[ExecuteInEditMode]
public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject Light;
    [SerializeField] Material Mat;
    [SerializeField] Light SpotLight;
    public Transform target;
    private bool LightActive = false;
    private Color originalAmbientColor;
    private float originalAmbientIntensity;

    private void Start()
    {
        Light.SetActive(false);
        originalAmbientColor = RenderSettings.ambientLight;
        originalAmbientIntensity = RenderSettings.ambientIntensity;
    }

    private void Update()
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
            RaycastHit hit;
            if (Physics.Raycast(SpotLight.transform.position, target.position - SpotLight.transform.position, out hit))
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
    }
}
