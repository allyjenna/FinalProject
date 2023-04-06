using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteAppear : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;

    private bool isNoteVisible = false;
    private bool isNoteVisibleFromClipboard = false;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isNoteVisible && Input.GetMouseButtonDown(0) && canvas.activeSelf && !isNoteVisibleFromClipboard)
        {
            canvas.SetActive(false);
            isNoteVisible = false;
        }
        isNoteVisibleFromClipboard = false;
    }

    void OnMouseDown()
    {
        canvas.SetActive(true);
        isNoteVisible = true;
        isNoteVisibleFromClipboard = true;
    }
}
