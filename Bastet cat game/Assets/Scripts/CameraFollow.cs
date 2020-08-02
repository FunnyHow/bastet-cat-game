using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;
    public Vector3 offset = Vector3.zero;


    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = offset + new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
    }
}
