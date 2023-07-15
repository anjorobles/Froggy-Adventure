using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawsound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource; // The audio source component

    private float Sawspeed = 2f;
    public float pitchMultiplier = 1.0f; // The multiplier for the pitch

    
    void Update()
    {
        float pitch = Mathf.Clamp(Sawspeed * pitchMultiplier, 1.0f, 3.0f); // Adjust the pitch based on the speed
        audioSource.pitch = pitch;
    }
}
