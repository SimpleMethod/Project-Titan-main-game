using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsHelper : MonoBehaviour {

   void OnCollisionEnter(Collision collision)
    {
        GameObject HitTarget = collision.gameObject;
        Health health = HitTarget.GetComponent<Health>();

        HealthObjects HealthObjects = HitTarget.GetComponent<HealthObjects>();
        if (health != null)
        {
            health.TakeDMG(10);
            HealthObjects.TakeDMG(10);
        }
        Destroy(gameObject);
    }

}
