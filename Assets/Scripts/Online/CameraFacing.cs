using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]

public class CameraFacing : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Camera cam = Camera.main;
        var point = cam.transform.position;
        transform.LookAt(point);
    }
}
