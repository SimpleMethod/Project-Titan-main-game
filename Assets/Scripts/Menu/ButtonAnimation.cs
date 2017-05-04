using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ButtonAnimation : MonoBehaviour
{
    private Animator anim;
    private CanvasGroup can;
    private bool RunStatus = false;
    int jumpHash = Animator.StringToHash("Start");

    private void Awake()
    {
        this.gameObject.AddComponent<CanvasGroup>();
        this.gameObject.AddComponent<Animator>();
        can = GetComponent<CanvasGroup>();
        anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = Resources.Load("Animations/ButtonsPanelsFadeIn/Buttons") as RuntimeAnimatorController; 
        can.alpha = 0;
    }

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown(KeyMap._Submit) && RunStatus != true)
        {
            can.alpha = 1;
            anim.SetTrigger(jumpHash);
            anim.StopPlayback();
            RunStatus = true;
        }
    }

}
