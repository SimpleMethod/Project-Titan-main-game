using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]

public class AmmoSystem : MonoBehaviour
{

    public bool AddAmmo;
    public int ValueAmmo;
    void OnCollisionEnter(Collision collision)
    {
        GameObject HitTarget = collision.gameObject;
        SimpleMove Simplemove = HitTarget.GetComponent<SimpleMove>();

        if (Simplemove != null)
        {
            if (AddAmmo == false)
            {

                Simplemove.AmmoSystem(false, ValueAmmo);
            }
            else
            {
                Simplemove.AmmoSystem(true, ValueAmmo);
            }

        }
    }

}
