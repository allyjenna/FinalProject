using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FloatingText : MonoBehaviour
{
    public float speed;
    public float interval;
    public Vector2 direction;
    public TextMeshProUGUI[] textObjects;

    private int currentIndex = 0;
    private float timer = 0;
    private bool canStart = false;

    void Start()
    {
        // Set all text objects to disabled
        foreach (TextMeshProUGUI textObject in textObjects)
        {
            RectTransform rectTransform = textObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = Vector2.zero;
            textObject.enabled = false;
        }

        // Wait for 2 seconds before showing the first text object
        StartCoroutine(ShowFirstTextAfterDelay(2f));
    }

    IEnumerator ShowFirstTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        textObjects[currentIndex].enabled = true;
        canStart = true;
    }

    void Update()
    {
        if (!canStart)
        {
            return;
        }

        // Update the timer
        timer += Time.deltaTime;

        // If the interval has elapsed, show the next text object and select the next one
        if (timer >= interval)
        {
            // Disable the current text object
            textObjects[currentIndex].enabled = false;

            // Move to the next text object
            currentIndex = (currentIndex + 1) % textObjects.Length;

            // Show the next text object
            textObjects[currentIndex].enabled = true;

            // Reset the timer
            timer = 0;
        }

        // Move the current text object
        RectTransform rectTransform = textObjects[currentIndex].GetComponent<RectTransform>();
        rectTransform.anchoredPosition += direction * speed * Time.deltaTime;

        // Load scene 0 after 15 seconds
        if (Time.timeSinceLevelLoad > 15f)
        {
            SceneManager.LoadScene(0);
        }
    }
}
