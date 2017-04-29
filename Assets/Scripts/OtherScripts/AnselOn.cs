using NVIDIA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnselOn : MonoBehaviour {
    Ansel.SessionData session = new Ansel.SessionData();
    private double mCurrentTime;
    // Use this for initialization
    void Start () {
        session.isAnselAllowed = true;
        session.isFovChangeAllowed = true;
        session.isHighresAllowed = true;
        session.isPauseAllowed = true;
        session.isRotationAllowed = false;
        session.isTranslationAllowed = false;
        session.is360StereoAllowed = false;
        session.is360MonoAllowed = false;
        
    }
	

	// Update is called once per frame
	void Update () {
        
        if (NVIDIA.Ansel.IsSessionActive)
        {
            mCurrentTime += Time.deltaTime;
            Debug.LogWarning("ZSSS");

            return;
        }
        else
        {
          //  camera.SetActive(true);
        }
        mCurrentTime += Time.deltaTime;
    }
}
