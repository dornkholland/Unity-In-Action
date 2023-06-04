using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY=0,
        MouseX=1,
        MouseY=2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float verticalRot = 0;
    // Start is called before the first frame update
    void Start()
    {
        // rigidBody property to keep walking animation from affecting mouse input
        Rigidbody body = GetComponent<Rigidbody>();
            if (body != null)
        {
            body.freezeRotation = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            //horizontal rotation here
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            // vertical rotation here
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);
            float horizontalRot = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
        else if (axes == RotationAxes.MouseXAndY)
        {
            // both horizontal and vertical rotation go here
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

            float horizontalRot = transform.localEulerAngles.y;
            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            horizontalRot += delta;

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot , 0);
        }
    }
}
