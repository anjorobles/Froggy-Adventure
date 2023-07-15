using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RespawnTime : MonoBehaviour
{
    private float currentTime = 0f;
    public float startingtime = 3f;
    private bool IsRespawning = false;
    public Text respawnTime;
    //private PlayerLife playerLife;
    void Start()
    {
        gameObject.SetActive(false);
        //playerLife = FindObjectOfType<PlayerLife>();
    }

   
    void Update()
    {
        if (IsRespawning)
        {
            currentTime -= 1 * Time.deltaTime;
            if (currentTime <=0)
            {
                currentTime = 0;
            }
            else
            {
                respawnTime.text = currentTime.ToString("0");
            }
        }
        
        
    }

    public void StartRespawnTime()
    {
        currentTime = startingtime;
        IsRespawning = true;
        gameObject.SetActive(true);
        respawnTime.text = currentTime.ToString("0");

    }
}
