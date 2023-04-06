using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 1.0f;

    private Quaternion initialRotation;
    private float maxRotation;
    private float minRotation;

    void Start()
    {
        initialRotation = transform.localRotation;
        maxRotation = initialRotation.eulerAngles.y + 45f;
        minRotation = initialRotation.eulerAngles.y - 45f;
    }

    void Update()
    {
        float yRotationInput = Input.GetAxis("Mouse X") * rotationSpeed;

        float yRotation = transform.localRotation.eulerAngles.y;
        yRotation += yRotationInput;
        yRotation = Mathf.Clamp(yRotation, minRotation, maxRotation);

        transform.localRotation = Quaternion.Euler(initialRotation.eulerAngles.x, yRotation, initialRotation.eulerAngles.z);
    }
}
