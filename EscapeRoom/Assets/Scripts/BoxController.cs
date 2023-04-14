using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip appear;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnMouseDown()
    {
        // Play the push animation when the button is clicked
        GetComponent<Animator>().SetTrigger("box");

        // Set the ButtonClicked parameter to true
        GetComponent<Animator>().SetBool("box", true);
        StartCoroutine(PlayDelayed(1f));


    }

    public IEnumerator PlayDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.PlayOneShot(appear);
    }

   

}
