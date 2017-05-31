using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSystem : MonoBehaviour {

    public bool AddAmmo;
    void OnCollisionEnter(Collision collision)
    {
        GameObject HitTarget = collision.gameObject;
        SimpleMove Simplemove = HitTarget.GetComponent<SimpleMove>();

        if (Simplemove != null)
        {
            if (AddAmmo == false)
            {

                Simplemove.AmmoSystem(false,1);
            }
            else
            {
                Simplemove.AmmoSystem(true,1);
            }

        }
        Debug.LogWarning("Debug Ammo");
    }

}
