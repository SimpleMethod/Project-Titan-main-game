using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(DestructionObject))]

public class BulletsHelper : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        GameObject HitTarget = collision.gameObject;
        Health health = HitTarget.GetComponent<Health>();
        DestructionObject DestructionObject = HitTarget.GetComponent<DestructionObject>();
        if (health != null)
        {
            health.TakeDMG(10);
        }
        if (DestructionObject != null)
        {
            DestructionObject.TakeDMG(10);
        }
        Destroy(gameObject);
    }
}