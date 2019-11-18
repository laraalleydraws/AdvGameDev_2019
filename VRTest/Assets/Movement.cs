using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform centerEye;
    public float speed = 1f;
    public float deadZoneThresh = 0.05f;
    private RaycastHit lastRaycastHit;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }

    }// Update is called once per frame
    void Update()

    {
        if (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).magnitude > deadZoneThresh)
        {
            gameObject.transform.position += centerEye.forward * (Time.deltaTime * speed);
        }
    RaycastHit hit;

    if(Physics.Raycast(righthandController.position, righthandController.forward, out hit))
    {
        Transform.position = hit.point;
    }
}

