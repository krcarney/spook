﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitvity = 150f;
    public Transform playerBody;

    private float move_delay = 0.5f;
    float xRotation = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Camera shouldn't move until user is loaded in
        if (Time.timeSinceLevelLoad < move_delay)
        {
            return;
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitvity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitvity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
