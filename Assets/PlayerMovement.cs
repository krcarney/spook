using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    private float speed = 4f;
    private float shrinkFactor = 0.5f;
    private bool isCrouched;

    // Start is called before the first frame update
    void Start()
    {
        isCrouched = false;
    }

    // Update is called once per frame
    void Update()
    {
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
