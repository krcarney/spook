using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;

    private void Awake()
    {
        Spawn[] spawns = FindObjectsOfType<Spawn>();

        // Place player
        int player_loc = Random.Range(0, spawns.Length);
        Instantiate(player, spawns[player_loc].transform.position, spawns[player_loc].transform.rotation);

        // Place monster
        int monster_loc = Random.Range(0, spawns.Length);
        while (monster_loc == player_loc)
        {
            monster_loc = Random.Range(0, spawns.Length);
        }
        Instantiate(monster, spawns[monster_loc].transform.position, Quaternion.identity);
    }
}
