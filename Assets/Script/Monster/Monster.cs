using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    private PlayerMovement player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();

        FindObjectOfType<NavMeshSurface>().BuildNavMesh();
    }

    private void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
    }
}
