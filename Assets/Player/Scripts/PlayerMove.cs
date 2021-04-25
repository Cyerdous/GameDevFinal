using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = 9.8f;
    public float jumpspeed = 8.0f;
    private float deltaY = 0;

    private CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = (CharacterController)GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CanJump() && Input.GetButton("Jump"))
            deltaY = jumpspeed;
        else if (_characterController.isGrounded)
            deltaY = 0;
        else
            deltaY -= gravity*Time.deltaTime;

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.Set(movement.x, deltaY, movement.z);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        _characterController.Move(movement);
    }

    bool CanJump()
    {
        //later can add multi-jump support
        return _characterController.isGrounded;
    }
}
