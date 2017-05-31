using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public const float MaxHealth = 100f;
    [SyncVar(hook = "UpdateProgressBar")] public float RealHealth = MaxHealth;
    public RectTransform HealthBar;
    // (hook = "UpdateProgressBar")
    Text HealthText;
    
    public void UpdateProgressBar(float scale)
    {
      //  Text cameraLabel = GameObject.Find("HealthText").GetComponent<Text>();
        HealthBar.localScale = new Vector3(scale / 100, 1, 1);
        Debug.LogWarning("Health value:"+scale);
        //   cameraLabel.text = scale.ToString();

        if (isLocalPlayer)
        {
            HealthText = GameObject.Find("HealthText").GetComponent<Text>();
            HealthText.text = RealHealth.ToString();
        }
    }
    public void TakeDMG(float value)
    {
     //   if(!isServer)
     //  {
     //      return;
     //   }


        RealHealth -= value;
        if(RealHealth<=0)
        {
            RealHealth = MaxHealth;
            Debug.LogError("PlayerDead");
         //   SendData._livestatus = false;
           Rpc_Respawn();
         //   SendData._livestatus = false;
        }
        UpdateProgressBar(RealHealth);
    }

    public void TakeHealth(float value)
    {
        //   if(!isServer)
        //  {
        //      return;
        //   }


        RealHealth += value;
        UpdateProgressBar(RealHealth);


    }

    [ClientRpc]
    void Rpc_Respawn()
   {

       if (isLocalPlayer)
       {
           transform.position = Vector3.zero;
        }

    }

    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
