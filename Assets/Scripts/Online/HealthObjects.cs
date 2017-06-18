using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

[RequireComponent(typeof(Text))]
[RequireComponent(typeof(RectTransform))]

public class HealthObjects : NetworkBehaviour
{

    public const float MaxHealth = 100f;
    [SyncVar(hook = "UpdateProgress")] public float RealHealth = MaxHealth;
    public RectTransform HealthBar;
    public Text HealthText;
    public void UpdateProgress(float scale)
    {
        Debug.LogWarning(scale);
    }
    public void TakeDMG(float value)
    {
        RealHealth -= value;
        if (RealHealth <= 0)
        {
            RealHealth = MaxHealth;
            Destroy(gameObject);
        }
        UpdateProgress(RealHealth);
    }

}
