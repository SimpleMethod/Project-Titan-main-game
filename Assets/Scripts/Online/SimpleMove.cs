using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;
using UnityEngine.UI;
public class SimpleMove : NetworkBehaviour
{

    [SyncVar] public string PlayerID;

   private Text AmmoText;
    public GameObject Bullet;
    public Transform BulletSpawner;

    public GameObject cameraplace;
    public Rigidbody RigBody;

    private float speed = 4.0F;
    private float rotationSpeed = 100.0F;
    [SerializeField]
    private float speedbullet = 200f;
    private int status = 0;


    [SerializeField]
    private float cameraRotationLimit = 85f;

    private int AmmoValue;


    [Command]
    public void CmdChangeName(string newName)
    {
        //  PlayerID =  SendData._uniqueid + " HASH:" + Random.Range(-10.0f, 10.0f);

#if UNITY_EDITOR
        PlayerID = "Gracz";
#else
      PlayerID = SendData._uniqueid;
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


    public void AmmoSystem (bool option, int value)
    {
        if(option==false)
        { AmmoValue = AmmoValue - value; }
        else
        { AmmoValue = AmmoValue + value; }
       
    }

    void Start()
    {
    
        if (isLocalPlayer)
        {
            status = 1;
            SendData._livestatus = true;
            SendData._openchat = false;
            SendData._openmenu = false;
            AmmoValue = 10;
        }

    }
    void Update()
    {
        this.GetComponentInChildren<Text>().text = PlayerID;
        if (status == 1)
        {
            float _xMov = Input.GetAxis("Horizontal");
            float _zMov = Input.GetAxis("Vertical");
            Vector3 _movHorizontal = transform.right * _xMov;
            Vector3 _movVertical = transform.forward * _zMov;
            Vector3 _velocity = (_movHorizontal + _movVertical) * speed;
            float _yRot = Input.GetAxisRaw("Mouse X");
            Vector3 _rotation = new Vector3(0f, _yRot, 0f) * 50;
            float _xRot = Input.GetAxisRaw("Mouse Y");
            float _cameraRotationX = _xRot * 5;
            Quaternion deltaRotation = Quaternion.Euler(_rotation * Time.deltaTime * 5);
            //  float translation = CrossPlatformInputManager.GetAxis("Vertical") * speed;
            //  float rotation = CrossPlatformInputManager.GetAxis("Horizontal") * rotationSpeed;
            ////  translation *= Time.deltaTime;
            //  rotation *= Time.deltaTime;
            // transform.Translate(0, 0, translation);
            //  transform.Rotate(0, rotation, 0);
            RigBody.AddForce(_velocity);
            RigBody.MoveRotation(RigBody.rotation * deltaRotation);
            if (/*(SendData._openmenu == false || SendData._openchat == false || SendData._livestatus == true) ||*/  AmmoValue>0 && CrossPlatformInputManager.GetButtonDown(KeyMap._Fire1))
            {
                CmdFire();
                --AmmoValue;
                Debug.LogError("Ammo: " + AmmoValue);
            }
            if (isLocalPlayer)
            {
                AmmoText = GameObject.Find("AmmoText").GetComponent<Text>();
                AmmoText.text = AmmoValue.ToString();
            }
        }
    }




    [Command]
    void CmdFire()
    {
        GameObject bullet = (GameObject)Instantiate(Bullet, BulletSpawner.position, BulletSpawner.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 30;
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 2);
    }


    public override void OnStartLocalPlayer()
    {

        //    base.OnStartLocalPlayer();
        GetComponent<MeshRenderer>().material.color = Color.red;
        CmdChangeName("dD");

    }
}
