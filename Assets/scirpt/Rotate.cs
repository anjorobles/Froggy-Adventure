using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //private bool isRotating = false;
    [SerializeField] private float speed = 2f;
   // [SerializeField] private AudioSource audioSource;
    void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
