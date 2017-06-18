using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class ChangeText : MonoBehaviour
{
    public Text TextOnPanel;
    public string FileName;
    public string SearchRequest;
    public int[] NumberOfElements;
    public string SearchRequestChildren;
    public int SekundyDoZmiany;
    [SerializeField]
    private Text txt;
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