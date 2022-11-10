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
    public float horSensitivity = 9.0f;
    public float vertSensitivity = 9.0f;
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
            float rotationDelta = horSensitivity * Input.GetAxis("Horizontal") * Time.deltaTime;
            transform.Rotate(0, rotationDelta, 0);
        } 
        if (mouseAxis == MouseAxis.Y)
        {
            float rotationDelta = horSensitivity * Input.GetAxis("Horizontal") * Time.deltaTime;
            vertRotation = Mathf.Clamp(vertRotation, minVertAngle, maxVertAngle);

            float horizontalRot = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(vertRotation, horizontalRot, 0);
        }
    }
}
