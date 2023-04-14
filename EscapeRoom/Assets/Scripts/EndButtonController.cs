using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButtonController : MonoBehaviour
{
    public Animator wallAnimator;
    public Animator portalAnimator;
    public GameObject box;
    public GameObject player;
    public Vector3 targetPosition;
    public bool boxDestroyed = false;
    public GameObject portal;
    public float maxDistance = 15f;
    [SerializeField] private Camera mainCamera;

    public AudioSource wallAudioSource;
    public AudioSource portalAudioSource;

    private void Start()
    {
        wallAnimator = GameObject.Find("Wall").GetComponent<Animator>();
        portalAnimator = GameObject.Find("Portal").GetComponent<Animator>();
        boxDestroyed = false;
        portal.SetActive(false);
    }

    void OnGUI()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                var selection = hit.transform;
                if (selection.CompareTag("EndButton"))
                {
                    portal.SetActive(true);

                    player.transform.position = targetPosition;
                    player.transform.rotation = Quaternion.Euler(0f, 180f, 0f); // Rotate 90 degrees on Y-axis

                    // Trigger the "Open" animation for the wall
                    wallAnimator.SetTrigger("Open");

                    // Trigger the "Open" animation for the portal
                    portalAnimator.SetTrigger("Open");
                    Destroy(box);
                    boxDestroyed = true;

                    wallAudioSource.Play();
                    portalAudioSource.Play();
                }
            }
        }
    }
}
