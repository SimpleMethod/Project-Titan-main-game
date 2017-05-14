using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;
using UnityEngine.UI;
public class SimpleMove : NetworkBehaviour
{

    [SyncVar] public string PlayerID = "dD";

    public GameObject Bullet;
    public Transform BulletSpawner;

    public GameObject cameraplace;


    private float speed = 10.0F;
    private float rotationSpeed = 100.0F;
    private float speedbullet = 7.0F;
    private int status = 0;



    [Command]
    public void CmdChangeName(string newName)
    {
        PlayerID =  SendData._uniqueid + " HASH:" + Random.Range(-10.0f, 10.0f);

#if UNITY_EDITOR
        PlayerID = Random.Range(-10.0f, 10.0f).ToString();
#else
     PlayerID =  SendData._uniqueid;
#endif
    }

    void OnGUI()
    {
        if (isLocalPlayer)
        {
            Camera.main.transform.position = cameraplace.transform.position;
            Camera.main.transform.rotation = cameraplace.transform.rotation;
            PlayerID = GUI.TextField(new Rect(Screen.width / 2, 0, 100, 30), PlayerID);
            CmdChangeName(PlayerID);
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
            SendData._livestatus = true;
            SendData._openchat = false;
            SendData._openmenu = false;
        }

    }
    void Update()
    {
        this.GetComponentInChildren<Text>().text = PlayerID;
        if (status == 1)
        {
            float translation = CrossPlatformInputManager.GetAxis("Vertical") * speed;
            float rotation = CrossPlatformInputManager.GetAxis("Horizontal") * rotationSpeed;
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);

            if (/*(SendData._openmenu == false || SendData._openchat == false || SendData._livestatus == true) ||*/ CrossPlatformInputManager.GetButtonDown(KeyMap._Fire1))
            {
                CmdFire();
            }
        }
    }

    [Command]
    void CmdFire()
    {
        GameObject bullet = (GameObject)Instantiate(Bullet, BulletSpawner.position, BulletSpawner.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * speedbullet;
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 2);
    }

   
    public override void OnStartLocalPlayer()
    {

        //    base.OnStartLocalPlayer();
        GetComponent<MeshRenderer>().material.color = Color.red;
        CmdChangeName("");

    }
}
