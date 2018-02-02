using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {

    float sensitivity = 10; // X angles run upside down: negative is up, positive is down

    float limUp = -70; // max angle up 
    float limDn = 50; // max angle down

    private Vector3 euler;

    void Start()
    {
        euler = transform.localEulerAngles; // save initial euler angles 
    }

    void Update()
    {
        euler.z -= Input.GetAxis("Mouse Y") * sensitivity;
        euler.z = Mathf.Clamp(euler.z, limUp, limDn);
        transform.localEulerAngles = euler;
    }
}
