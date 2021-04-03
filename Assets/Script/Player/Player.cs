using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Awake()
    {
        // Place player
        Spawn[] spawns = FindObjectsOfType<Spawn>();
        transform.position = spawns[Random.Range(0, spawns.Length)].transform.position;
    }
}
