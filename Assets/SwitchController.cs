using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour
{
    [SerializeField] private float dragDistance = 1f;
    [SerializeField] private float dragDuration = 0.5f;
    [SerializeField] public UnityEvent onSwitchDown;

    private bool isDragging = false;
    private Vector3 dragStartPosition;

    void OnMouseDown()
    {
        // Record the start position of the drag
        isDragging = true;
        dragStartPosition = Input.mousePosition;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            // Calculate the distance and direction of the drag
            float dragDistancePixels = Input.mousePosition.y - dragStartPosition.y;
            float dragDistanceWorld = dragDistancePixels * dragDistance / Screen.height;

            // Rotate the switch downward
            float rotationAngle = Mathf.Clamp(dragDistanceWorld, -dragDistance, 0f);
            transform.localRotation = Quaternion.Euler(rotationAngle, 0f, 0f);

            // Check if the switch has been dragged all the way down
            if (rotationAngle <= -dragDistance)
            {
                isDragging = false;
                StartCoroutine(SwitchDownCoroutine());
            }
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    public IEnumerator SwitchDownCoroutine()
    {
        // Wait for a moment before calling the event
        yield return new WaitForSeconds(dragDuration);

        // Check if the onSwitchDown event is subscribed to
        if (onSwitchDown != null)
        {
            Debug.Log("onSwitchDown event is subscribed to");
            // Call the onSwitchDown event
            onSwitchDown.Invoke();
        }
        else
        {
            Debug.Log("onSwitchDown event is not subscribed to");
        }
    }

}
