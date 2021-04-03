using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    private Vector3 starting_position;
    private float position_scroll_speed = 2f;
    private float position_jump_scale = 0.1f;

    private float base_intensity = 1f;
    private float intensity_scroll_speed = 1f;
    private float intensity_jump_scale = 0.1f;

    private void Start()
    {
        starting_position = transform.localPosition;
    }

    void Update()
    {
        GetComponent<Light>().intensity = GetIntensity();
        transform.localPosition = starting_position + GetPosition();
    }

    private float GetIntensity()
    {
        return (base_intensity + (intensity_jump_scale * Mathf.PerlinNoise(Time.time * intensity_scroll_speed, 1f + Time.time * intensity_scroll_speed)));
    }

    private Vector3 GetPosition()
    {
        float x = Mathf.PerlinNoise(Time.time * position_scroll_speed, 1f + Time.time * position_scroll_speed) - 0.5f;
        float y = Mathf.PerlinNoise(Time.time * position_scroll_speed, 1f + Time.time * position_scroll_speed) - 0.5f;
        float z = Mathf.PerlinNoise(Time.time * position_scroll_speed, 1f + Time.time * position_scroll_speed) - 0.5f;
        return new Vector3(x, y, z) * position_jump_scale;
    }
}
