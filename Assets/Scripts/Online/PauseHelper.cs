using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Text))]
[RequireComponent(typeof(GameObject))]

public class PauseHelper : NetworkBehaviour
{
    public GameObject PauseMenu, CrossHair;
    public Text[] Text;
    private void Awake()
    {
        PauseMenu.gameObject.SetActive(false);
    }
    void Start()
    {
        ReadJsonFileHelper ReadFileJ = new ReadJsonFileHelper();
        Text[0].GetComponent<Text>().text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "Disconnect");
        Text[1].GetComponent<Text>().text = ReadFileJ.ReadJsonFile(SendData._File, SendData._language, "ExitV2");
    }
    public void DisconnectFromServer()
    {
        NetworkManager.Shutdown();
        PauseMenu.gameObject.SetActive(false);
    }
    public void CloseApp()
    {
        Debug.Log("Exit from game");
        PauseMenu.gameObject.SetActive(false);
        Application.Quit();
    }
    void Update()
    {

        if (CrossPlatformInputManager.GetButtonDown(KeyMap._Cancel))
        {
            if (SendData._openmenu == true)
            {
                PauseMenu.gameObject.SetActive(false);
                CrossHair.gameObject.SetActive(true);
                Debug.Log("Close pause menu");
                SendData._openmenu = false;

            }
            else
            {
                PauseMenu.gameObject.SetActive(true);
                CrossHair.gameObject.SetActive(false);
                Debug.Log("Open menu pause");
                SendData._openmenu = true;
            }

        }
    }
}
