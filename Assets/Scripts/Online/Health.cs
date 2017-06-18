using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

[RequireComponent(typeof(Text))]

public class Health : NetworkBehaviour
{

    public const float MaxHealth = 100f;
    [SyncVar(hook = "UpdateProgressBar")] public float RealHealth = MaxHealth;
    public RectTransform HealthBar;
    [SerializeField]
    private Text HealthText;

    public void UpdateProgressBar(float scale)
    {
        HealthBar.localScale = new Vector3(scale / 100, 1, 1);
        Debug.LogWarning("Health value:" + scale);
        if (isLocalPlayer)
        {
            HealthText = GameObject.Find("HealthText").GetComponent<Text>();
            HealthText.text = scale.ToString();
        }
    }
    public void TakeDMG(float value)
    {
        RealHealth -= value;
        if (RealHealth <= 0)
        {
            RealHealth = MaxHealth;
            Rpc_Respawn();
            Debug.LogError("Player is dead");
            if(isLocalPlayer)
            {
                Functions.RequestToServer(SendData._uniqueid, 3, 1);
            }
            Functions.RequestToServer(SendData._uniqueid, 3, 1);
        }
        UpdateProgressBar(RealHealth);
    }

    public void TakeHealth(float value)
    {
        RealHealth += value;
        UpdateProgressBar(RealHealth);
    }

    [ClientRpc]
    void Rpc_Respawn()
    {

        if (isLocalPlayer)
        {
            float X = Random.Range(-40.0f, 40.0f);
            float Z = Random.Range(-25.0f, 25.0f);
            transform.position = new Vector3(X, 0, Z);
            Functions.RequestToServer(SendData._uniqueid, 5, 1);
            Functions.RequestToServer(SendData._uniqueid, 4, 1);
        }

    }
    private void Start()
    {
        Text HealthText = GameObject.Find("HealthText").GetComponent<Text>();
        HealthText.text = 100.ToString();
    }
}
