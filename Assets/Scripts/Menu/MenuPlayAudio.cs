using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class MenuPlayAudio : MonoBehaviour
{
    public void PlayAudio()
    {
        AudioSource audio = this.gameObject.GetComponent<AudioSource>();
        audio.volume = SendData._master_Volume;
        audio.Play();
    }
}
