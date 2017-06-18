using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;
using UnityEngine.UI;

[RequireComponent(typeof(GameObject))]
[RequireComponent(typeof(Text))]
[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody))]

public class SimpleMove : NetworkBehaviour
{

    [SyncVar]
    public string PlayerID;

    public GameObject Td1, Td2;

    public GameObject Crosshair;

    public GameObject Bullet;
    public Transform BulletSpawner;
    public GameObject cameraplace;
    public Rigidbody RigBody;

    [SerializeField]
    private NetworkStartPosition[] spawnPoints;
    [SerializeField]
    private Text AmmoText;
    [SerializeField]
    private float speed = 15.0F;
    [SerializeField]
    private int status = 0;
    [SerializeField]
    private int AmmoValue;
    [SerializeField]
    private bool StatusMove;

    [Command]
    public void CmdChangeName(string newName)
    {
        PlayerID = newName;
    }

    private void Awake()
    {
#if UNITY_EDITOR
        CmdChangeName(Random.Range(-10.0f, 10.0f).ToString());
        PlayerID = Random.Range(-10.0f, 10.0f).ToString();

#else
   CmdChangeName(SendData._uniqueid);
        PlayerID=SendData._uniqueid;
#endif
    }

    void OnGUI()
    {

        if (isLocalPlayer)
        {
            Td1.name = GetInstanceID().ToString();
            Td2.name = GetInstanceID().ToString();
            Td1.layer = LayerMask.NameToLayer("NPC");
            Td2.layer = LayerMask.NameToLayer("NPC");
            Camera.main.transform.position = cameraplace.transform.position;
            Camera.main.transform.rotation = cameraplace.transform.rotation;
            PlayerID = GUI.TextField(new Rect(Screen.width / 2, 0, 100, 30), PlayerID);

        }
    }


    public void AmmoSystem(bool option, int value)
    {
        if (option == false)
        {
            if (AmmoValue > 0)
            {
                AmmoValue = AmmoValue - value;
            }
        }
        else
        { AmmoValue = AmmoValue + value; }

    }

    void Start()
    {

        if (isLocalPlayer)
        {

            CmdChangeName(SendData._uniqueid);
            status = 1;
            SendData._livestatus = true;
            SendData._openchat = false;
            SendData._openmenu = false;
            StatusMove = false;
            AmmoValue = 10;
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
            Vector3 spawnPoint = Vector3.zero;
            if (spawnPoints != null && spawnPoints.Length > 0)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }
            transform.position = spawnPoint;
        }

    }
    void Update()
    {
        this.GetComponentInChildren<Text>().text = PlayerID;
        StopMove();
        if (status == 1 && SendData._openmenu == false)
        {
            float _xMov = Input.GetAxis("Horizontal");
            float _zMov = Input.GetAxis("Vertical");
            Vector3 _movHorizontal = transform.right * _xMov;
            Vector3 _movVertical = transform.forward * _zMov;
            Vector3 _velocity = (_movHorizontal + _movVertical) * speed;
            float _yRot = Input.GetAxisRaw("Mouse X");
            Vector3 _rotation = new Vector3(0f, _yRot, 0f) * 50;
            Quaternion deltaRotation = Quaternion.Euler(_rotation * Time.deltaTime * 5);
            RigBody.AddForce(_velocity);
            RigBody.MoveRotation(RigBody.rotation * deltaRotation);
            if (AmmoValue > 0 && CrossPlatformInputManager.GetButtonDown(KeyMap._Fire1))
            {
                CmdFire();
                --AmmoValue;
                Debug.Log("Ammo: " + AmmoValue);
            }
            if (isLocalPlayer)
            {
                AmmoText = GameObject.Find("AmmoText").GetComponent<Text>();
                AmmoText.text = AmmoValue.ToString();
            }
        }

    }


    private void StopMove()
    {
        if (CrossPlatformInputManager.GetButtonDown(KeyMap._Cancel))
        {
            if (StatusMove == true)
            {
                RigBody.isKinematic = false;
                StatusMove = false;
            }
            else
            {
                RigBody.isKinematic = true;
                StatusMove = true;
            }

        }
    }

    [Command]
    void CmdFire()
    {
        GameObject bullet = (GameObject)Instantiate(Bullet, BulletSpawner.position, BulletSpawner.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 37;
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 2);
    }


    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
