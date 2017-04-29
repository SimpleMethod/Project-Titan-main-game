using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsOptions : MonoBehaviour
{
    private int temp;
    public GameObject Panel;
    public GameObject SettingspPop;
    public GameObject pop;
    public Button[] btn;
    public Text textgameobject, SettingspPopText;

    ReadJsonFileHelper ReadFileJ = new ReadJsonFileHelper();
    void Start()
    {
        //GameObject objToSpawn;
        //objToSpawn = new GameObject("PANEL #2");
      //  Panel.AddComponent<Canvas>();
        SettingspPop.gameObject.SetActive(false);
        pop.gameObject.SetActive(false);
    }

    public void NewBtn()
    {
        pop.gameObject.SetActive(true);
        btn[0].GetComponent<Button>().onClick.AddListener(delegate { NewGame(); });
        btn[1].GetComponent<Button>().onClick.AddListener(delegate { CanelPopUP(); });
       // ReadJsonFileHelper ReadFileJ = new ReadJsonFileHelper();
        Text text = textgameobject.GetComponent<Text>();
        text.text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "QuestionNewGame");
    }
    public void ExitBtn()
    {
        pop.gameObject.SetActive(true);
        btn[0].GetComponent<Button>().onClick.AddListener(delegate { CloseApp(); });
        btn[1].GetComponent<Button>().onClick.AddListener(delegate { CanelPopUP(); });
       // ReadJsonFileHelper ReadFileJ = new ReadJsonFileHelper();
        Text text = textgameobject.GetComponent<Text>();
        text.text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "Question");
    }
    public void SetBtn()
    {
        Debug.Log("DD");
        SettingspPop.gameObject.SetActive(true);
        //btn[0].GetComponent<Button>().onClick.AddListener(delegate { NewGame(); });
      //  btn[1].GetComponent<Button>().onClick.AddListener(delegate { CanelPopUP(); });
    
       Text text = textgameobject.GetComponent<Text>();
        SettingspPopText.text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "OptimalPlayableSettings");
    }


    /// <summary>
    /// /
    /// </summary>
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
