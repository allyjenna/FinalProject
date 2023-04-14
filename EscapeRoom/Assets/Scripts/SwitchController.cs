using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour
{
    [SerializeField] private float dragDistance = 1f;
    [SerializeField] private float dragDuration = 0.5f;
    [SerializeField] private AudioClip electricitySound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] public UnityEvent onSwitchDown;

    public bool isSwitchDown = false;

    void Start()
    {
        // Get the AudioSource component attached to this object
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown");

        if (!isSwitchDown)
        {
            Debug.Log("Switching down");

            // Rotate the switch downward
            transform.localRotation = Quaternion.Euler(-dragDistance, 0f, 0f);

            // Set isSwitchDown to true
            isSwitchDown = true;

            // Play the electricity sound
            if (electricitySound != null && audioSource != null)
            {
                audioSource.PlayOneShot(electricitySound);
            }

            // Start the coroutine to trigger the onSwitchDown event
            StartCoroutine(SwitchDownCoroutine());
        }
    }

    public IEnumerator SwitchDownCoroutine()
    {
        Debug.Log("SwitchDownCoroutine started");

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
