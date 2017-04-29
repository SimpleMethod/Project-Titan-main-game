using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayAudio : MonoBehaviour
{

    public void PlayAudio()
    {
        AudioSource audio = this.gameObject.GetComponent<AudioSource>();
        audio.Play();
    }

}
