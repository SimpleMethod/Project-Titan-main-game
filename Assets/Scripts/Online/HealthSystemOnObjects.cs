using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystemOnObjects : MonoBehaviour {
    public bool AddHealth;
    void OnCollisionEnter(Collision collision)
    {
        GameObject HitTarget = collision.gameObject;
        Health health = HitTarget.GetComponent<Health>();

        if (health != null)
        {
            if(AddHealth == false)
            {

                health.TakeDMG(10);
            }
            else
            {
                health.TakeHealth(10);
            }
         
        }
        Debug.LogWarning("Debug Health");
    }

}
