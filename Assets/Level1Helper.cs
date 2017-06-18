using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using NVIDIA;
public class Level1Helper : MonoBehaviour {

	void Update () {
        if (!NVIDIA.Ansel.IsSessionActive && CrossPlatformInputManager.GetButtonDown(KeyMap._Cancel))
        {
            Functions.SelectLoadLevel("menu");
        }
    }
}
