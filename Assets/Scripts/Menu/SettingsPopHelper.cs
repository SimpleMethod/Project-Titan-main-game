using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
[RequireComponent(typeof(Dropdown))]
[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(Toggle))]
[RequireComponent(typeof(GameObject))]

public class SettingsPopHelper : MonoBehaviour
{
    public Text[] Text;
    public Dropdown[] Dropdown;
    public Slider Slider;
    public Toggle Toogle;
    public GameObject pop;
    private bool status;
    private float ToggleSatus;
    public struct Resolution
    {
        public int ID, Width, Height;
        public String Name;
    }
    public struct QualityLevel
    {
        public int ID, level;
        public String Name;
    }
    public struct FPSLimits
    {
        public int ID;
        public float Name;
    }
    ReadJsonFileHelper ReadFileJ = new ReadJsonFileHelper();
    Resolution[] res = new Resolution[11];
    QualityLevel[] qul = new QualityLevel[6];
    FPSLimits[] fps = new FPSLimits[9];
    public void GenerationResolution()
    {
        // Screen.currentResolution.width Screen.currentResolution.height;
        //Debug.Log(Screen.currentResolution.width + "x" + Screen.currentResolution.height);
        res[0].ID = 0;
        res[0].Width = 1280;
        res[0].Height = 720;
        res[0].Name = "1280×720 (16:9)";
        res[1].ID = 1;
        res[1].Width = 1280;
        res[1].Height = 768;
        res[1].Name = "1280x768 (16:10)";
        res[2].ID = 2;
        res[2].Width = 1280;
        res[2].Height = 800;
        res[2].Name = "1280x800 (16:10)";
        res[3].ID = 3;
        res[3].Width = 1360;
        res[3].Height = 768;
        res[3].Name = "1360x768 (16:9)";
        res[4].ID = 4;
        res[4].Width = 1366;
        res[4].Height = 768;
        res[4].Name = "1366x768 (16:9)";
        res[5].ID = 5;
        res[5].Width = 1600;
        res[5].Height = 900;
        res[5].Name = "1600x900 (16:9)";
        res[6].ID = 6;
        res[6].Width = 1920;
        res[6].Height = 1080;
        res[6].Name = "1920x1080 (16:9)";
        res[7].ID = 7;
        res[7].Width = 1920;
        res[7].Height = 1200;
        res[7].Name = "1920x1200 (16:10)";
        res[8].ID = 8;
        res[8].Width = 2048;
        res[8].Height = 1152;
        res[8].Name = "2048x1152 (16:9)";
        res[9].ID = 9;
        res[9].Width = 2560;
        res[9].Height = 1440;
        res[9].Name = "2560x1440 (16:9)";
        res[10].ID = 10;
        res[10].Width = 3840;
        res[10].Height = 2160;
        res[10].Name = "3840x2160 (16:9)";

        qul[0].ID = 0;
        qul[0].level = 0;
        qul[0].Name = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "VeryLow");
        qul[1].ID = 1;
        qul[1].level = 1;
        qul[1].Name = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "Low");
        qul[2].ID = 2;
        qul[2].level = 2;
        qul[2].Name = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "Medium");
        qul[3].ID = 3;
        qul[3].level = 3;
        qul[3].Name = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "High");
        qul[4].ID = 4;
        qul[4].level = 4;
        qul[4].Name = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "VeryHigh");
        qul[5].ID = 5;
        qul[5].level = 5;
        qul[5].Name = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "Ultra");

        fps[0].ID = 0;
        fps[0].Name = 30;
        fps[1].ID = 1;
        fps[1].Name = 60;
        fps[2].ID = 2;
        fps[2].Name = 90;
        fps[3].ID = 3;
        fps[3].Name = 120;
        fps[4].ID = 4;
        fps[4].Name = 144;
        fps[5].ID = 5;
        fps[5].Name = 166;
        fps[6].ID = 6;
        fps[6].Name = 240;
        fps[7].ID = 7;
        fps[7].Name = 300;
        fps[8].ID = 8;
        fps[8].Name = 360;
        List<string> Qality = new List<string> { ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "VeryLow"), ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "Low"), ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "Medium"), ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "High"), ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "VeryHigh"), ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "Ultra") };
        List<string> ResDropDown = new List<string> { "1280×720 (16:9)", "1280x768 (16:10)", "1280x800 (16:10)", "1360x768 (16:9)", "1366:768 (16:9)", "1600x900 (16:9)", "1920x1080 (16:9)", "1920x1200 (16:10)", "2048x1152 (16:9)", "2560x1440 (16:9)", "3840x2160 (16:9)", "NaN" };
        List<string> FPSLimits = new List<string> { "30", "60", "90", "120", "144", "166", "240", "300", "360" };
        Dropdown[0].AddOptions(ResDropDown);
        Dropdown[1].AddOptions(FPSLimits);
        Dropdown[2].AddOptions(Qality);

        for (int i = 0; i < 11; i++)
        {
            if (res[i].Width == SendData._resolutionW && res[i].Height == SendData._resolutionH)
            {
                Dropdown[0].value = i;
                if (i == 11)
                {
                    Dropdown[0].value = 11;
                }
            }
        }
        switch (SendData._FPSLimit)
        {

            case 30:
                Dropdown[1].value = 0;
                break;
            case 60:
                Dropdown[1].value = 1;
                break;
            case 90:
                Dropdown[1].value = 2;
                break;
            case 120:
                Dropdown[1].value = 3;
                break;
            case 144:
                Dropdown[1].value = 4;
                break;
            case 166:
                Dropdown[1].value = 5;
                break;
            case 244:
                Dropdown[1].value = 6;
                break;
            case 300:
                Dropdown[1].value = 7;
                break;
            case 360:
                Dropdown[1].value = 8;
                break;
            default:
                Dropdown[1].value = 0;
                break;
        }

    }

    // Use this for initialization
    void Start()
    {
        GenerationResolution();
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
        Text text7 = Text[7].GetComponent<Text>();
        text7.text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "Refuse");
        Slider.value = SendData._master_Volume;
        Dropdown[2].value = QualitySettings.GetQualityLevel();
        Toogle.isOn = SendData._vsync;
        status = true;
    }

    public void UpdateVoice()
    {
    }
    public void UpdateResolution()
    {
    }
    public void UpdateVerticalSync()
    {
        if (Toogle.isOn)
        {
            ToggleSatus = 1.0f;
        }
        else
        {
            ToggleSatus = 0.0f;
        }
    }
    public void UpdateFrameRate()
    {
    }
    public void UpdateQuality()
    {
    }

    public void SaveConfig()
    {
        if (status == true)
        {

            Functions.UpdateConfig("Audio.Master_Volume", Slider.value);
            Functions.UpdateConfig("Graphic.SetResolutionW", res[Dropdown[0].value].Width);
            Functions.UpdateConfig("Graphic.SetResolutionH", res[Dropdown[0].value].Height);
            Functions.UpdateConfig("Graphic.FPSMaxRender", fps[Dropdown[1].value].Name);
            Functions.UpdateConfig("Graphic.OverallGraphicsQuality", qul[Dropdown[2].value].level);
            Functions.UpdateConfig("Graphic.vSyncCount", ToggleSatus);

        }
    }

    public void CloseApp()
    {
        Debug.Log("Zamknięcie aplikacji");
        pop.gameObject.SetActive(false);
    }
}
