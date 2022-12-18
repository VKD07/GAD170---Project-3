using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarCanvas : MonoBehaviour
{
    public Transform mainCamera;
    private void Start()
    {
        mainCamera = Camera.main.transform;
    }
    void LateUpdate()
    {
        //keep looking at the camera with a delay
        transform.LookAt(transform.position + mainCamera.forward);
    }
}
