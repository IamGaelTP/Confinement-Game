using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{

    CharacterController characterController;

    [Header("Player Settings")]
    public float walkSpeed = 6.0f;
    public float gravity = 20.0f;
    Vector3 move = Vector3.zero;

    [Header("Camera Settings")]
    public Camera cam;
    public float mouseHorizontal = 3.0f;
    public float mouseVertical = 2.0f;
    public float minRotation = -65.0f;
    public float maxRotation = 60.0f;
    float h_mouse, v_mouse;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        //Block cursor
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        //Camera
        h_mouse = mouseHorizontal * Input.GetAxis("Mouse X");
        v_mouse += mouseVertical * Input.GetAxis("Mouse Y");

        v_mouse = Mathf.Clamp(v_mouse, minRotation, maxRotation);

        //Rotate Camera
        cam.transform.localEulerAngles = new Vector3(-v_mouse, 0, 0); //Vertical
        transform.Rotate(0, h_mouse, 0); //Horizontal


        //Movement
        if (characterController.isGrounded)
        {
            //Local Position
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            //World Position
            move = transform.TransformDirection(move) * walkSpeed;
        }
        move.y -= gravity * Time.deltaTime;

        characterController.Move(move * Time.deltaTime);
    }
}
