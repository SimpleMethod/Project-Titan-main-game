using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(AudioSource))]
public class Menu : MonoBehaviour
{
    //  public Animator anim;
    // int jumpHash = Animator.StringToHash("Start");
    private bool RunStatus = false;
    static public bool ReadyToGetID;
    public AudioClip audioClip;
    public Text textgameobject, signgameobject;
    ReadJsonFileHelper ReadFileJ = new ReadJsonFileHelper();
    // public CanvasGroup PanelButton;

    void Start()
    {
        // anim = GetComponent<Animator>();
    }

    void Update()
    {

        Text text = textgameobject.GetComponent<Text>();
        Text sign = signgameobject.GetComponent<Text>();

        if (ReadyToGetID)
        {

#if UNITY_EDITOR
            SendData._uniqueid = "1";
#endif

            if (SendData._uniqueid != null)
            {
                sign.color = new Color32(30, 255, 0, 255);
                text.text = String.Format(ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "Status"), ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "StatusArray", 1, "text"));
                SendData._OnlineAccess = true;
            }
            else
            {
                UnityEngine.Debug.LogError("Błąd otwarcia pliku MENU");
                sign.color = new Color32(255, 242, 0, 255);
                text.text = String.Format(ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "Status"), ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "StatusArray", 2, "text"));
                SendData._OnlineAccess = false;
            }

        }

        if (CrossPlatformInputManager.GetButtonDown(KeyMap._Submit) && RunStatus != true)
        {
            //  anim.SetTrigger(jumpHash); //   anim.StopPlayback(); //PanelButton.alpha = 0; // Animacja 
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            audio.volume = SendData._master_Volume;
            
            RunStatus = true;
        }
    }
}