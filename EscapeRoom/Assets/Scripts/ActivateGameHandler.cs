using UnityEngine;

public class ActivateGameHandler : MonoBehaviour
{
    public GameObject gameHandler;

    private void Start()
    {
        gameHandler.SetActive(false);

        // Call the ActivateGameHandlerDelayed method after 10 seconds
        Invoke("ActivateGameHandlerDelayed", 10f);
    }

    private void ActivateGameHandlerDelayed()
    {
        // Activate the gameHandler object
        gameHandler.SetActive(true);
    }
}
