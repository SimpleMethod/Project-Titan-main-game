using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Text))]

public class MenuTextHelper : MonoBehaviour
{
    private bool RunStatus = false;
    public Canvas AntiClicker;
    public Animator anim, anim2;
    public Text textgameobject;
    int jumpHash = Animator.StringToHash("Start");
    ReadJsonFileHelper ReadFileJ = new ReadJsonFileHelper();
    void Start()
    {
        Text text = textgameobject.GetComponent<Text>();
        text.text = String.Format(ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "MenuStartText"), ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "KeySpace"));

#if UNITY_EDITOR
        CanvasGroup EDITORHeler;
        GameObject CanvasEDITORHelper = GameObject.Find("Buttons");
        EDITORHeler = CanvasEDITORHelper.GetComponent<CanvasGroup>();
        EDITORHeler.alpha = 1f;
#else
        CanvasGroup EDITORHeler;
        GameObject CanvasEDITORHelper = GameObject.Find("Buttons");
        EDITORHeler = CanvasEDITORHelper.GetComponent<CanvasGroup>();
        EDITORHeler.alpha = 0f;
#endif


        anim = GetComponent<Animator>();
        GameObject anim2Helper = GameObject.Find("Buttons");
        anim2 = anim2Helper.GetComponent<Animator>();
        text = GetComponent<Text>();
    }
    void StarAnimation() { }

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown(KeyMap._Submit) && RunStatus != true)
        {

            Destroy(AntiClicker);
            Menu.ReadyToGetID = true;
            anim.SetTrigger(jumpHash);
            anim.StopPlayback();
            anim2.SetTrigger(jumpHash);
            anim2.StopPlayback();
            textgameobject.enabled = false;
            RunStatus = true;
        }
    }
}