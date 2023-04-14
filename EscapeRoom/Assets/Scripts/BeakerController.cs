
using UnityEngine;
using System.Collections;

public class BeakerController : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public void OnMouseDown()
    {

        // Play the push animation when the button is clicked
        GetComponent<Animator>().SetTrigger("Spill");

        // Set the ButtonClicked parameter to true
        GetComponent<Animator>().SetBool("Spill", true);


    }

    public IEnumerator PlayDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Play();
    }

    public void SpillAudio()
    {
        StartCoroutine(PlayDelayed(1f));
    }

}
