using System.Collections;
using System.Linq;
using UnityEngine;

public class PadLockPassword : MonoBehaviour
{
    TimeBlinking tb;
    MoveRuller _moveRull;
    PadLockEmissionColor _rullers;
    public int[] _numberPassword = { 0, 0, 0, 0 };
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera lockCamera;
    public GameObject Lock;
    public GameObject classDoor;
    public GameObject galleryDoor;
    public GameObject player;
    public Vector3 targetPosition;

    public float maxDistance = 15f;
    public Canvas lockCanvas;

    private AudioSource audioSource;
    public AudioClip correct;

    private bool playedsound = false;




    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        tb = FindObjectOfType<TimeBlinking>();
        mainCamera.enabled = true;
        lockCamera.enabled = false;
        lockCanvas.enabled = false;
        Lock.SetActive(true);
        classDoor.SetActive(true);
        galleryDoor.SetActive(true);
    }

    void Awake()
    {
        _moveRull = FindObjectOfType<MoveRuller>();
        _rullers = FindObjectOfType<PadLockEmissionColor>();

    }

    public void Password()
    {
        if (_moveRull._numberArray.SequenceEqual(_numberPassword))
        {


            StartCoroutine(OpenDoorCoroutine());

            // Es. Below the for loop to disable Blinking Material after the correct password
            for (int i = 0; i < _moveRull._rullers.Count; i++)
            {
                _moveRull._rullers[i].GetComponent<PadLockEmissionColor>().correctPassword = true;
                _moveRull._rullers[i].GetComponent<PadLockEmissionColor>().BlinkingMaterial();

            }

            if (!playedsound)
            {
                audioSource.PlayOneShot(correct);
                playedsound = true;
            }

        }
    }

    private IEnumerator OpenDoorCoroutine()
    {

        yield return new WaitForSeconds(2f);
        mainCamera.enabled = true;
        lockCamera.enabled = false;
        lockCanvas.enabled = false;
        Lock.SetActive(false);
        classDoor.SetActive(false);
        galleryDoor.SetActive(false);
        player.transform.position = targetPosition;

    }

    void OnGUI()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (lockCamera.enabled)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Pressed E key");
                player.transform.position = targetPosition;
                mainCamera.enabled = true;
                lockCamera.enabled = false;
                lockCanvas.enabled = false;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out RaycastHit hit, maxDistance))
            {
                if (hit.transform.CompareTag("Padlock"))
                {
                    Debug.Log("Selected Padlock");
                    mainCamera.enabled = false;
                    lockCamera.enabled = true;
                    lockCanvas.enabled = true;
                }
            }
        }
    }




}
