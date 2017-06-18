using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class PopUpHelper : MonoBehaviour
{
    public Text textgameobject;
    public string TextToText;
    ReadJsonFileHelper ReadFileJ = new ReadJsonFileHelper();

    public void UpdateText(string TextToShow)
    {
        Text text = textgameobject.GetComponent<Text>();
        text.text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, TextToText);
    }
}
