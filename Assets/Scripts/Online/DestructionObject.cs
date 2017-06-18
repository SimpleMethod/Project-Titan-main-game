using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

[RequireComponent(typeof(GameObject))]

public class DestructionObject : NetworkBehaviour
{
    [SyncVar] public int Health;

    void OnCollisionEnter(Collision collision)
    {
        GameObject HitTarget = collision.gameObject;
        BulletsHelper BulletsHelper = HitTarget.GetComponent<BulletsHelper>();

        if (BulletsHelper != null)
        {
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public void TakeDMG(float value)
    {
        Health = (int)(Health - value);
    }
}