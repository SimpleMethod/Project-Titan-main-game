using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopHelper : MonoBehaviour {
    public Text[] Text;
    public Dropdown[] Dropdown;
    public Slider Slider;
    public Toggle Toogle;

    ReadJsonFileHelper ReadFileJ = new ReadJsonFileHelper();

    public void GenerationResolution()
    {
        // Screen.currentResolution.width Screen.currentResolution.height;
        Debug.Log(Screen.currentResolution.width + "x" + Screen.currentResolution.height);
    }

    // Use this for initialization
    void Start () {
        Text text1 = Text[0].GetComponent<Text>();
        text1.text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "Volume");
        Text text2 = Text[1].GetComponent<Text>();
        text2.text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "Resolution");
        Text text3 = Text[2].GetComponent<Text>();
        text3.text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "VerticalSync");
        Text text4 = Text[3].GetComponent<Text>();
        text4.text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "FrameRate");
        Text text5 = Text[4].GetComponent<Text>();
        text5.text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "Quality");
        Text text6 = Text[5].GetComponent<Text>();
        text6.text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "Update");
        Text text7= Text[7].GetComponent<Text>();
        text7.text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "Refuse");
        Slider.value = SendData._master_Volume;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
