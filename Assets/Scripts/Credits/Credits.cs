using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Credits : MonoBehaviour
{
    public GameObject OstatniElement;
    private bool temp;
    void Start()
    {
        PlayAudio();
    }
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown(KeyMap._Cancel))
        {
            Functions.SelectLoadLevel("menu");
        }
        if(OstatniElement.activeInHierarchy)
        {
            temp = true;
        }
        if(!OstatniElement.activeInHierarchy && temp==true)
        {
            Functions.SelectLoadLevel("menu");
        }
    }

    public void PlayAudio()
    {
        AudioSource audio = this.gameObject.GetComponent<AudioSource>();
        audio.volume = SendData._master_Volume;
        audio.Play();
    }
}
