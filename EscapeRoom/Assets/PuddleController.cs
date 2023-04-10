using System.Collections;
using UnityEngine;

public class PuddleController : MonoBehaviour
{
    public AudioClip dropSound;
    public float colorChangeAmount = 0.1f;
    public int maxDrops = 3;
    public GameObject drop;
    public GameObject hidden;
    public GameObject reveal;
    public ParticleSystem smokeParticles;

    private int currentDrops = 0;
    private AudioSource audioSource;
    private Renderer puddleRenderer;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        puddleRenderer = GetComponent<Renderer>();
        hidden.SetActive(true);
        reveal.SetActive(false);

        Debug.Log("audioSource assigned: " + (audioSource != null));
        Debug.Log("puddleRenderer assigned: " + (puddleRenderer != null));
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("A trigger event has occurred!");

        if (other.gameObject == drop)
        {
            Debug.Log("A drop has hit the puddle!");

            currentDrops++;
            audioSource.PlayOneShot(dropSound);

            // Change the color of the puddle
            Color newColor = puddleRenderer.material.color;
            newColor.r += colorChangeAmount;
            puddleRenderer.material.color = newColor;

            // Check if all the drops have hit the puddle
            if (currentDrops >= maxDrops)
            {
                Debug.Log("Puddle is fully red now!");
                smokeParticles.Play();

                StartCoroutine(Text());

              
               
            }
        }
    }

    private IEnumerator Text()
    {
        yield return new WaitForSeconds(4f);
        hidden.SetActive(false);
        reveal.SetActive(true);
        StartCoroutine(Destroy());
    }


    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(smokeParticles);
    }

}
