using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1Controller : MonoBehaviour
{
    public GameObject rope1;

    public void OnClick()
    {        
        Destroy(rope1);
    }
}
