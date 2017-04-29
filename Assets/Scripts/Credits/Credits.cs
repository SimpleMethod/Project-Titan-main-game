using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Credits : MonoBehaviour
{

    void Start()
    {

    }
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown(KeyMap._Cancel))
        {
            Functions.SelectLoadLevel("Menu");
        }
    }
}
