using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI scoreText;
    public GameObject gameOverscreenUI;

    int minutes, seconds, score;
    // Start is called before the first frame update
    void Start()
    {
        gameOverscreenUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver()
    {
        gameOverscreenUI.SetActive(true);
        //display score and time
        minutes = PlayerPrefs.GetInt("minutes");
        seconds = PlayerPrefs.GetInt("seconds");
        score = PlayerPrefs.GetInt("Score");
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        scoreText.text = "X " + score;

    }
    
}
