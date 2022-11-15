using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public enum MouseAxis 
    {
        X = 0,
        Y = 1
        };

    public MouseAxis mouseAxis = MouseAxis.X;
    public float horSensitivity = 3.0f;
    public float vertSensitivity = 3.0f;
    public float maxVertAngle = 45f;
    public float minVertAngle = -45f;

    // Start is called before the first frame update
    public float vertRotation = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseAxis == MouseAxis.X)
        {
            float rotationDelta = horSensitivity * Input.GetAxis("Mouse X");
            transform.Rotate(0, rotationDelta, 0);
        } 
        if (mouseAxis == MouseAxis.Y)
        {
            float rotationDelta = vertSensitivity * Input.GetAxis("Mouse Y");
            vertRotation = Mathf.Clamp(vertRotation - rotationDelta, minVertAngle, maxVertAngle);

            float horizontalRot = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(vertRotation, horizontalRot, 0);
        }
    }
}
