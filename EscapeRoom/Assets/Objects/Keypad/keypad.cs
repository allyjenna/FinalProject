//333333333333333333333333333333333333333333333333333333333333333333\\
//
//          Arthur: Cato Parnell
//          Description of script: control keypad button clicks and actions
//          Any queries please go to Youtube: Cato Parnell and ask on video. 
//          Thanks.
//
//33333333333333333333333333333333333333333333333333333333333333333\\

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keypad : MonoBehaviour
{
    [SerializeField] private Camera lockCamera;
    [SerializeField] private Camera mainCamera;
    //public GameObject KeypadGameobject;

    // *** CAN DELETE THESE ** \\
    // Used to hide joystick and slider
    //[Header("Objects to Hide/Show")]
    //public GameObject objectToDisable;
    //public GameObject objectToDisable2;

    // Object to be enabled is the keypad. This is needed
    public GameObject objectToEnable;
    public GameObject player;
    public GameObject doormove;
    public GameObject keypadmove;
    public Vector3 targetPosition;
    public GameObject targetCollider;
    public float maxDistance = 15f;



    // *** Breakdown of header(public) variables *** \\
    // curPassword : Pasword to set. Ive set the password in the project. Note it can be any length and letters or numbers or sysmbols
    // input: What is currently entered
    // displayText : Text area on keypad the password entered gets displayed too.
    // audioData : Play this sound when user enters in password incorrectly too many times

    [Header("Keypad Settings")]
    public string curPassword;
    public string input;
    public Text displayText;
    public AudioSource audioData;
    public AudioSource correct;


    //Local private variables
    private bool keypadScreen;
    private float btnClicked = 0;
    private float numOfGuesses;

    // Start is called before the first frame update
    void Start()
    {
        lockCamera.enabled = false;
        doormove.SetActive(true);
        doormove.SetActive(true);
        keypadmove.SetActive(true);


        btnClicked = 0; // No of times the button was clicked
        numOfGuesses = curPassword.Length; // Set the password length.
    }

    // Update is called once per frame
    void Update()
    {

        //if (lockCamera.enabled == true)
        //{
        //    Cursor.visible = true;

        //}

        //if (mainCamera.enabled == true)
        //{
        //    Cursor.visible = false;

        //}

        if (btnClicked == numOfGuesses)
        {
            if (input == curPassword)
            {
                //Load the next scene
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                // LOG message that password is correct
                Debug.Log("Correct Password!");
                correct.Play();
                displayText.text = input.ToString();
                btnClicked = 0;

                StartCoroutine(OpenDoorCoroutine());


            }
            else
            {
                //Reset input varible
                input = "";
                displayText.text = input.ToString();
                audioData.Play();
                btnClicked = 0;
            }

        }

    }

    private IEnumerator OpenDoorCoroutine()
    {

        yield return new WaitForSeconds(2f);
        mainCamera.enabled = true;
        lockCamera.enabled = false;
        objectToEnable.SetActive(false);
        keypadScreen = false;
        player.transform.position = targetPosition;
        doormove.SetActive(false);
        keypadmove.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetCollider)
        {
            doormove.SetActive(true); // Activate the door game object
        }
    }



    void OnGUI()
    {

        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
        //    // Action for clicking keypad( GameObject ) on screen
        //    if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hit;
        //    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            //Debug.Log($"Mouse position: {Input.mousePosition}");
            //Debug.Log($"Ray direction: {ray.direction}");

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                var selection = hit.transform;

                if (selection == null)
                {
                    Debug.Log("Selection is null");
                }
                else if (selection.CompareTag("keypad"))
                {

                    keypadScreen = true;

                    mainCamera.enabled = false;
                    lockCamera.enabled = true;

                    var selectionRender = selection.GetComponent<Renderer>();
                    if (selectionRender != null)
                    {
                        keypadScreen = true;
                    }
                }
            }

        }
    

        // Disable sections when keypadScreen is set to true
        if (keypadScreen)
        {

            objectToEnable.SetActive(true);

        }

        
    }



    public void ValueEntered(string valueEntered)
    {
        switch (valueEntered)
        {
            case "Q": // QUIT
                //objectToDisable.SetActive(true);
                //objectToDisable2.SetActive(true);
                objectToEnable.SetActive(false);
                btnClicked = 0;
                keypadScreen = false;
                lockCamera.enabled = false;
                mainCamera.enabled = true;
                input = "";
                displayText.text = input.ToString();
                break;

            case "C": //CLEAR
                input = "";
                btnClicked = 0;// Clear Guess Count
                displayText.text = input.ToString();
                break;

            default: // Buton clicked add a variable
                btnClicked++; // Add a guess
                input += valueEntered;
                displayText.text = input.ToString();
                break;
        }


    }
}
