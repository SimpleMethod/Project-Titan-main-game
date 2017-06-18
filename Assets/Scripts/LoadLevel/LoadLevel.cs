using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Animator))]

public class LoadLevel : MonoBehaviour
{
    public Image ProgressBar;
    public string levelName;
    AsyncOperation async;
    public Animator anim;
    int Out = Animator.StringToHash("Out");
    // public CanvasGroup im;

    public void StartLoading()
    {

        if (SendData._levelload != null)
        {
            levelName = SendData._levelload;
        }
        StartCoroutine("load");
    }
    public void UpdateProgressBar(float scale)
    {
        ProgressBar.rectTransform.localScale = new Vector3(scale, 1, 1);
    }
    IEnumerator load()
    {
        async = SceneManager.LoadSceneAsync(levelName);
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            // [0, 0.9] > [0, 1]
            float ProgressBarLevel = Mathf.Clamp01(async.progress + 0.1f);
            UpdateProgressBar(ProgressBarLevel);
            // Załadowano w 100%
            if (async.progress == 0.9f)
            {
                anim.SetTrigger(Out);
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                {
                    ActivateScene();
                }
            }
            yield return null;
        }
    }

    public void ActivateScene()
    {
        async.allowSceneActivation = true;
    }
    private void Start()
    {
        UpdateProgressBar(0.0f);
        //   im.alpha = 0.5f;
        StartLoading();

    }

    private void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown(KeyMap._Jump))
        {
            ActivateScene();
        }
    }
}