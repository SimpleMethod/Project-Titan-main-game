using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class ButtonsLang : MonoBehaviour
{
    public Text[] Text;
    void Start()
    {
        ReadJsonFileHelper ReadFileJ = new ReadJsonFileHelper();
        Text[0].GetComponent<Text>().text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "SourceCode");
        Text[1].GetComponent<Text>().text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "NewGame");
        Text[2].GetComponent<Text>().text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "OnlineMode");
        Text[3].GetComponent<Text>().text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "LoadGame");
        Text[4].GetComponent<Text>().text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "Settings");
        Text[5].GetComponent<Text>().text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "Credits");
        Text[6].GetComponent<Text>().text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "Exit");
    }
}
