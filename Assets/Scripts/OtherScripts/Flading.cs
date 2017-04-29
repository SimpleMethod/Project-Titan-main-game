using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flading : MonoBehaviour {
    public Texture2D TextureForFade;
    public float FadeSpeed = 0.8f;
    private int HierarchyGui = -1000;
    private float alpha = 1.0f;
    private int FadeDir = -1;
	// Use this for initialization
	void OnGui () {
        alpha += FadeDir * FadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.r, alpha);
        GUI.depth = HierarchyGui;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), TextureForFade);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
