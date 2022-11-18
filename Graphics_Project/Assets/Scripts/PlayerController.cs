using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = 9.8f;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()

    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float deltaX = speed * Input.GetAxis("Horizontal");
        float deltaZ = speed * Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(deltaX, -gravity, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        characterController.Move(movement);
    }
}
