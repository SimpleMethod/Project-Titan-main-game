using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class HealthObjects : NetworkBehaviour
{

    public const float MaxHealth = 100f;
    [SyncVar(hook = "UpdateProgressBar")] public float RealHealth = MaxHealth;
    public RectTransform HealthBar;
    public Text HealthText;
    // (hook = "UpdateProgressBar")

    public void UpdateProgressBar(float scale)
    {
        //  Text cameraLabel = GameObject.Find("HealthText").GetComponent<Text>();
   
        Debug.LogWarning(scale);
        //   cameraLabel.text = scale.ToString();
    }
    public void TakeDMG(float value)
    {
        RealHealth -= value;
        if (RealHealth <= 0)
        {
            RealHealth = MaxHealth;
            Destroy(gameObject);
        }
        UpdateProgressBar(RealHealth);
    }

}
