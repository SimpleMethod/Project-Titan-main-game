using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Text TextOnPanel;
    private Text txt;
    public string FileName;
    public string SearchRequest;
    public int[] NumberOfElements;
    public string SearchRequestChildren;
    public int SekundyDoZmiany;
   // ReadJsonFileHelper ReadFileJ = new ReadJsonFileHelper();

    void Start()
    {
        txt = TextOnPanel.GetComponent<Text>();
        txt.alignByGeometry = true;
        txt.alignment = TextAnchor.UpperCenter;
        StartCoroutine(ChangeTextHelper());
    }

    IEnumerator ChangeTextHelper()
    {
        ReadJsonFileHelper ReadFileJ = new ReadJsonFileHelper();
        while (true)
        {
            foreach (int i in NumberOfElements)
            {
                txt.text = ReadFileJ.ReadJsonFile(FileName, SendData._language, SearchRequest, i, SearchRequestChildren);
                yield return new WaitForSeconds(SekundyDoZmiany);

            }
        }
    }

}