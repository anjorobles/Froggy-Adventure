using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    public float speed;
    [SerializeField] private Renderer bgimage;
    //[SerializeField] private float x, y;
    
    void Update()
    {
        bgimage.material.mainTextureOffset += new Vector2(speed*Time.deltaTime, 0);
    }
}
