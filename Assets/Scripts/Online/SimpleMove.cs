using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;
public class SimpleMove : NetworkBehaviour
{

    [SyncVar]
    public string nick = "Gracz ";

    public GameObject Pistolet;
    public Transform PistoletSpawn;
    float Szybkosc = 10f;
    float ObrotSzybkosc = 100f;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        float Ruch = CrossPlatformInputManager.GetAxis("Vertical") * Szybkosc;
        float Obrot = CrossPlatformInputManager.GetAxis("Horizontal") * ObrotSzybkosc;
        Ruch *= Time.deltaTime;
        Obrot *= Time.deltaTime;
        transform.Translate(0, 0, Ruch);
        transform.Rotate(0, Obrot, 0);

        if (CrossPlatformInputManager.GetButtonDown(KeyMap._Submit))
        {
            Fire();
        }

    }

    void Fire()
    {
        GameObject pocisk = (GameObject)Instantiate(Pistolet, PistoletSpawn.position, PistoletSpawn.rotation);
        pocisk.GetComponent<Rigidbody>().velocity = pocisk.transform.forward * 10f;
        Destroy(pocisk, 3f);
    }
    public override void OnStartLocalPlayer()
    {
        //    base.OnStartLocalPlayer();
        this.GetComponentInChildren<TextMesh>().text = nick;
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
