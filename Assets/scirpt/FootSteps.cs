using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioSource audioSource; // The audio source component
    public Rigidbody2D rb2d; // The rigidbody component of the game object
    public float pitchMultiplier = 1.0f; // The multiplier for the pitch

    void Update()
    {
        float speed = rb2d.velocity.magnitude;
        float pitch = Mathf.Clamp(speed * pitchMultiplier, 1.0f, 3.0f); // Adjust the pitch based on the speed
        audioSource.pitch = pitch;
    }
}
