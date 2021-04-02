using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 4f;
    private float shrinkFactor = 0.5f;
    private bool isCrouched;
    private float startingSpeed;
    private GameObject player;

    private bool teleport = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        startingSpeed = speed;

        isCrouched = false;
    }

    private void OnTriggerExit(Collider other)
    {
        speed = startingSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        speed = startingSpeed * 3;
        if (other.tag == "TeleporterEntrance")
        {
            teleport = true;
        }
    }
    
    void Update()
    {
        if (teleport)
        {
            teleport = false;

            var exit = GameObject.FindWithTag("TeleporterExit");
            Vector3 exitLocation = exit.transform.position;

            exitLocation.y = exitLocation.y + player.transform.position.y;

            player.transform.position = exitLocation;
            return;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        bool crouch = Input.GetKeyDown("left ctrl");
        Vector3 scale = transform.localScale;

        if (crouch)
        {
            if (!isCrouched)
            {
                print("isCrouched " + isCrouched);
                isCrouched = true;
                transform.localScale = new Vector3(0.0f, scale.y * shrinkFactor, 0.0f);
            }
            else
            {
                print("isCrouched " + isCrouched);
                isCrouched = false;
                transform.localScale = new Vector3(0.0f, scale.y / shrinkFactor, 0.0f);
            }
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }
}
