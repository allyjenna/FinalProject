using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emission : MonoBehaviour
{
    public float fadeSpeed = 1.0f;
    public float maxIntensity = 1.0f;

    private Material material;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        float newIntensity = Mathf.Clamp(material.GetColor("_EmissionColor").maxColorComponent + fadeSpeed * Time.deltaTime, 0.0f, maxIntensity);
        material.SetColor("_EmissionColor", new Color(newIntensity, newIntensity, newIntensity));
    }
}

