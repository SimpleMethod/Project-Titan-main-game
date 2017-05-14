using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class OnlineHelper : NetworkBehaviour {
    public GameObject[] Buttons;
    public GameObject Canvas;
	// Use this for initialization
	void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartupHost()
    {
        SetPort();
        NetworkManager.singleton.StartHost();
        Destroy(Canvas);
    }

    public void JoinGame()
    {
        SetIPAddress();
        SetPort();
        NetworkManager.singleton.StartClient();
        Destroy(Canvas);
    }
    void SetIPAddress()
    {
        string ipAddress = GameObject.Find("InputFieldIPAddress").transform.Find("Text").GetComponent<Text>().text;
        NetworkManager.singleton.networkAddress = ipAddress;
    }

    void SetPort()
    {
        NetworkManager.singleton.networkPort = 7777;
    }
}
