using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(GameObject))]

public class HealthSystemOnObjects : MonoBehaviour {
    public bool AddHealth;
    public int Value;
    void OnCollisionEnter(Collision collision)
    {
        GameObject HitTarget = collision.gameObject;
        Health health = HitTarget.GetComponent<Health>();

        if (health != null)
        {
            if(AddHealth == false)
            {

                health.TakeDMG(Value);
            }
            else
            {
                health.TakeHealth(Value);
            }
         
        }
        Debug.LogWarning("Debug Health");
    }

}
