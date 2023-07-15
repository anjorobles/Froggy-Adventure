using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public float StopTime;
    void Start()
    {
        Debug.Log("GameTimer Start() called."); 
        LoadTimer();
        SetTime(); 
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime += Time.deltaTime;
        SetTime(); 
    }

    public void SetTime()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        PlayerPrefs.SetInt("minutes", minutes);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("seconds", seconds);
        PlayerPrefs.Save();
    }

     public void SaveTime()
    {
        PlayerPrefs.SetFloat("Time", currentTime);
        PlayerPrefs.Save();
    }

    public void ResetTime()
    {
        currentTime = 0f;
        SaveTime();
        SetTime();
        Debug.Log("time reset");
    }

    private void LoadTimer()
    {
        timerText.color = Color.white;
        if (PlayerPrefs.HasKey("Time")) {
            currentTime = PlayerPrefs.GetFloat("Time");
        } else {
           currentTime = 0;
        }

         //Debug.Log("score =  " + currentTime);
    }

    public void StopTimer()
    {
        StopTime = currentTime;
        SetTime();
        timerText.color = Color.red;
        PlayerPrefs.SetFloat("Time", StopTime);
        PlayerPrefs.Save();
        enabled = false;
        //Debug.Log("enable =  " + enabled);
    }
}
