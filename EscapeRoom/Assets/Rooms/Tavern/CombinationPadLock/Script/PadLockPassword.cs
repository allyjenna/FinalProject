using System.Linq;
using UnityEngine;

public class PadLockPassword : MonoBehaviour
{
    MoveRuller _moveRull;
    public int[] _numberPassword = { 0, 0, 0, 0 };
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera lockCamera;
    public GameObject Lock;
    public GameObject Door;
    //private bool isOpened = false;

    void Awake()
    {
        _moveRull = FindObjectOfType<MoveRuller>();
    }

    public void Password()
    {
        if (_moveRull._numberArray.SequenceEqual(_numberPassword))
        {
            // Here enter the event for the correct combination
            mainCamera.enabled = true;
            lockCamera.enabled = false;
            //isOpened = true;

            // Move the player to a certain position
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = new Vector3(0f, 0.8560028f, 3f); // Change to the desired position
            }

            // Es. Below the for loop to disable Blinking Material after the correct password
            for (int i = 0; i < _moveRull._rullers.Count; i++)
            {
                _moveRull._rullers[i].GetComponent<PadLockEmissionColor>()._isSelect = false;
                _moveRull._rullers[i].GetComponent<PadLockEmissionColor>().BlinkingMaterial();
            }

            // Hide the padlock
            Lock.SetActive(false);

            // Rotate the door after 2 seconds
            Invoke("OpenDoor", 1f);
        }
    }

    private void OpenDoor()
    {
        Destroy(Door);

    }
}
