using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButtonController : MonoBehaviour
{
    public Animator wallAnimator;
    public Animator portalAnimator;
    public GameObject box;

    private void Start()
    {
        wallAnimator = GameObject.Find("Wall").GetComponent<Animator>();
        portalAnimator = GameObject.Find("Portal").GetComponent<Animator>();
    }

    public void OnMouseDown()
    {
        // Trigger the "Open" animation for the wall
        wallAnimator.SetTrigger("Open");

        // Trigger the "Open" animation for the portal
        portalAnimator.SetTrigger("Open");
        Destroy(box);
    }
}
