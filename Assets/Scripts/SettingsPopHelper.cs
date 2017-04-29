using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopHelper : MonoBehaviour {
    public Text[] Text;
    public Dropdown[] Dropdown;
    public Slider Slider;
    public Toggle Toogle;


    public void GenerationResolution()
    {
        // Screen.currentResolution.width Screen.currentResolution.height;
        Debug.Log(Screen.currentResolution.width + "x" + Screen.currentResolution.height);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
