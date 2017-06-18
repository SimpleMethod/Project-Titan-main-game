using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GameObject))]
[RequireComponent(typeof(Text))]
[RequireComponent(typeof(Button))]

public class ButtonsOptions : MonoBehaviour
{
    [SerializeField]
    private int temp;
    public GameObject Panel;
    public GameObject SettingspPop;
    public GameObject pop;
    public Button[] btn;
    public Text textgameobject, SettingspPopText;

    ReadJsonFileHelper ReadFileJ = new ReadJsonFileHelper();
    void Start()
    {
        SettingspPop.gameObject.SetActive(false);
        pop.gameObject.SetActive(false);
    }

    public void NewBtn()
    {
        pop.gameObject.SetActive(true);
        btn[0].GetComponent<Button>().onClick.AddListener(delegate { NewGame(); });
        btn[1].GetComponent<Button>().onClick.AddListener(delegate { CanelPopUP(); });
        Text text = textgameobject.GetComponent<Text>();
        text.text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "QuestionNewGame");
    }
    public void ExitBtn()
    {
        pop.gameObject.SetActive(true);
        btn[0].GetComponent<Button>().onClick.AddListener(delegate { CloseApp(); });
        btn[1].GetComponent<Button>().onClick.AddListener(delegate { CanelPopUP(); });
        Text text = textgameobject.GetComponent<Text>();
        text.text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "Question");
    }
    public void SetBtn()
    {
        SettingspPop.gameObject.SetActive(true);
        SettingspPopText.text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "OptimalPlayableSettings");
    }

    public void CloseApp()
    {
        Debug.Log("Zamknięcie aplikacji");
        Application.Quit();
        btn[0].GetComponent<Button>().onClick.RemoveAllListeners();
        btn[1].GetComponent<Button>().onClick.RemoveAllListeners();
        pop.gameObject.SetActive(false);
    }
    public void CanelPopUP()
    {
        Debug.Log("Zamknięcie oknca");
        btn[0].GetComponent<Button>().onClick.RemoveAllListeners();
        btn[1].GetComponent<Button>().onClick.RemoveAllListeners();
        pop.gameObject.SetActive(false);
        UnlockMenu();
    }
    public void NewGame()
    {
        Debug.Log("Nowa Gra");
        Functions.SelectLoadLevel("Level1");
        btn[0].GetComponent<Button>().onClick.RemoveAllListeners();
        btn[1].GetComponent<Button>().onClick.RemoveAllListeners();
        pop.gameObject.SetActive(false);
    }

    public void LoadCredits()
    {

        Debug.Log("Credits");
        Functions.SelectLoadLevel("Credits");
    }
    public void ShowSourceCode()
    {
        Application.OpenURL("https://github.com/SimpleMethod/-Retail-version-ProjectTitan-");
        Debug.Log("SourceCode");
    }
    public void ShowProgress()
    {
        Functions.OpenURL(SendData._uniqueid);
       
    }
    public void LoadOnline()
    {
        Debug.Log("Credits");
        if (SendData._OnlineAccess == true)
        {
            Functions.SelectLoadLevel("Online");
        }

    }
    public void LockMenu()
    {
        Debug.Log("Zablokowanie menu");
        Panel.AddComponent<Canvas>();
    }
    public void UnlockMenu()
    {
        Canvas Canvas = Panel.GetComponent<Canvas>();
        Debug.Log("Oblokowanie menu");
        Destroy(Canvas);
    }
}
