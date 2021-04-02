using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    private bool teleport = false;
    public GameObject exit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            teleport = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (teleport)
        {
            teleport = false;


        }
    }
}
