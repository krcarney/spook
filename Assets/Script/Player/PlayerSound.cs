using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private vp_FPController controller;

    public List<AudioClip> stone_footsteps;
    private float last_step = 0;
    private float current_step_cooldown = 0.5f;
    private AudioSource source;

    private void Start()
    {
        controller = GetComponent<vp_FPController>();
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        current_step_cooldown = 2f / controller.Velocity.magnitude;

        if (controller.Velocity.magnitude > 0 && !source.isPlaying && Time.timeSinceLevelLoad > last_step + current_step_cooldown)
        {
            last_step = Time.timeSinceLevelLoad;

            source.clip = stone_footsteps[Random.Range(0, stone_footsteps.Count)];
            source.pitch = Random.Range(1, 1.5f);
            source.Play();
        }
    }
}
