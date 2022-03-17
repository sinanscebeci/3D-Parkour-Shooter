using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    

    //Movement
    private CharacterController controller;
    public float speed;
    private float firstspeed;
    
    //Camera
    public float MouseSensitivity = 150f;
    private float xRotation = 0f;

    
    //Jumping and Gravity

    private Vector3 jumpvector;
    private float gravity = -9.81f;
    private bool grounded;
    private float aTimer;

    public Transform groundChecker;
    public float groundCheckerRadius = 0.25f;
    public LayerMask obstacleLayer;
    public float gravityDivider = 100f;
    public float jumpHeight = 0.2f;
    public float midairSpeed = 20f;
    
    
    
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        firstspeed = speed;
    }

    private void Update()
    {
        //Check if player is grounded
        
        grounded = Physics.CheckSphere(groundChecker.position, groundCheckerRadius, obstacleLayer);


        //Movement
        
        Vector3 moveInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        Vector3 moveVelocity = moveInputs * Time.deltaTime * speed;
        controller.Move(moveVelocity);

        //Camera
        
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * MouseSensitivity, 0);

        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * MouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);


        //Jumping and Gravity
        
        if (!grounded)
        {
            jumpvector.y += gravity * Time.deltaTime / gravityDivider;
            aTimer += Time.deltaTime / 3;
            speed = Mathf.Lerp(10, midairSpeed, aTimer);
        }
        else
        {
            jumpvector.y = -0.05f;
            speed = firstspeed;
            aTimer = 0;
        }
                
               
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {

            jumpvector.y = Mathf.Sqrt(jumpHeight * -2f * gravity / gravityDivider * Time.deltaTime);

        }
        
        controller.Move(jumpvector);
        
        



    }




}
