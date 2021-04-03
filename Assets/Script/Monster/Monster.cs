using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    private vp_FPController player;

    private void Start()
    {
        player = FindObjectOfType<vp_FPController>();

        FindObjectOfType<NavMeshSurface>().BuildNavMesh();
    }

    private void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
    }
}
