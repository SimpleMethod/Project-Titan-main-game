using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;
public class SimpleMove : NetworkBehaviour
{
    [SyncVar]
    public string PlayerID = "Gracz";
    public GameObject cameraplace;


    private  float speed = 10.0F;
    private float rotationSpeed = 100.0F;
    private int status = 0;

    [Command]
    public void CmdChangeName(string newName)
    {
        PlayerID = PlayerID + " ID:" + SendData._uniqueid + " HASH:" + Random.Range(-10.0f, 10.0f);
    }

    void OnGUI()
    {
        if (isLocalPlayer)
        {
            Camera.main.transform.position = cameraplace.transform.position;
            Camera.main.transform.rotation = cameraplace.transform.rotation;
            PlayerID = GUI.TextField(new Rect(Screen.width / 2, 0, 100, 30), PlayerID);
            //if (GUI.Button(new Rect(130, Screen.height - 40, 100, 30), "Change Name"))
            //{
            //    CmdChangeName(PlayerID);
            //}
        }
    }

    void Start()
    {
        if (isLocalPlayer)
        {
            status = 1;
           
        }

    }
    void Update()
    {
        this.GetComponentInChildren<TextMesh>().text = PlayerID;
        if (status==1)
        {
            float translation = CrossPlatformInputManager.GetAxis("Vertical") * speed;
            float rotation = CrossPlatformInputManager.GetAxis("Horizontal") * rotationSpeed;
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);
        }
    }
    public override void OnStartLocalPlayer()
    {
       
        //    base.OnStartLocalPlayer();
        GetComponent<MeshRenderer>().material.color = Color.red;
       CmdChangeName("");
        
    }
}
