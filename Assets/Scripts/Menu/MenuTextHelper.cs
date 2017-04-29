using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class MenuTextHelper : MonoBehaviour
{
    private bool RunStatus = false;
    public Canvas AntiClicker;
    public Animator anim;
    public Text textgameobject;
    int jumpHash = Animator.StringToHash("Start");
    ReadJsonFileHelper ReadFileJ = new ReadJsonFileHelper();
    //  int End = Animator.StringToHash("End");
    //  int runStateHash = Animator.StringToHash("Base Layer.Run");
    //private bool start;

    void Start()
    {

        // start = CrossPlatformInputManager.GetButtonDown("Jump");
        Text text = textgameobject.GetComponent<Text>();
        text.text = String.Format(ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "MenuStartText"), ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "KeySpace"));

        anim = GetComponent<Animator>();
        text = GetComponent<Text>();
    }
    void StarAnimation() { }

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown(KeyMap._Submit) && RunStatus != true)
        {
            
           Destroy(AntiClicker);
            Menu.ReadyToGetID = true;
            //  Debug.LogError(CrossPlatformInputManager.GetButtonDown("Jump"));         //    anim.SetTrigger(End);  //float move = Input.GetAxis("Vertical"); // anim.SetFloat("Speed", move);  //   AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
            anim.SetTrigger(jumpHash);
            anim.StopPlayback();
            textgameobject.enabled = false;
            RunStatus = true;
        }
    }
}