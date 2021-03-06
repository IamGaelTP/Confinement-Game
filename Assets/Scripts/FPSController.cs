﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{

    CharacterController characterController;

    [Header("Player Settings")] //Movement
    public float walkSpeed = 6.0f;
    public float gravity = 20.0f;
    Vector3 move = Vector3.zero;

    [Header("Camera Settings")] //Camera
    public Camera cam;
    public float mouseHorizontal = 3.0f;
    public float mouseVertical = 2.0f;
    public float minRotation = -65.0f;
    public float maxRotation = 60.0f;
    float h_mouse, v_mouse;
    public static bool lockRotation = false;
    public static bool lockMovement = false;

    [Header("Intro Text")] //Camera
    public GameObject canvasText;
    public GameObject textOne;
    public GameObject textTwo;

    void Awake()
    {
        canvasText.SetActive(false);
        textOne.SetActive(false);
        textTwo.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        //Block cursor
        Cursor.lockState = CursorLockMode.Locked;

        //Intro Text
        Invoke("IntroText", 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        //Camera
        h_mouse = mouseHorizontal * Input.GetAxis("Mouse X");
        v_mouse += mouseVertical * Input.GetAxis("Mouse Y");

        v_mouse = Mathf.Clamp(v_mouse, minRotation, maxRotation);

        //Rotate Camera
        if (!lockRotation)
        {
            cam.transform.localEulerAngles = new Vector3(-v_mouse, 0, 0); //Vertical
            transform.Rotate(0, h_mouse, 0); //Horizontal
        }
        else if (lockRotation)
        {
            cam.transform.localEulerAngles = new Vector3(0, 0, 0); //Vertical
            transform.Rotate(0, 0, 0); //Horizontal
        }
        //Movement
        if (characterController.isGrounded)
        {
            if (!lockMovement)
            {
                //Local Position
                move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
                //World Position
                move = transform.TransformDirection(move) * walkSpeed;

            }
            else if (lockMovement)
            {
                //Local Position
                move = new Vector3(0, 0.0f, 0);
                //World Position
                move = transform.TransformDirection(move) * 0;
            }
            
        }
        move.y -= gravity * Time.deltaTime;

        characterController.Move(move * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Teleport to EndRoom
        if (collision.gameObject.tag == "EndExit")
        {
            Application.Quit();
        }
    }

    void IntroText()
    {
        canvasText.SetActive(true);
        textOne.SetActive(true);
        textTwo.SetActive(false);
        //Disbale Text
        Invoke("DisableTextOne", 2.0f);
        //Intro Text Two
        Invoke("IntroTextTwo", 2.0f);

    }

    void IntroTextTwo()
    {
        textTwo.SetActive(true);
        //Disbale Text
        Invoke("DisableTextTwo", 3.0f);
    }

    void DisableTextOne()
    {
        textOne.SetActive(false);
    }

    void DisableTextTwo()
    {
        textTwo.SetActive(false);
        canvasText.SetActive(false);
    }

}
