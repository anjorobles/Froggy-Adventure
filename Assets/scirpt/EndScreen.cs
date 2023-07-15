using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI scoreText;
    public TextMeshProUGUI textField;
    public GameObject EndScreenUI;
    public GameObject EnterNameUI;
    int minutes, seconds, score;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("endscreen start()");
        EndScreenUI.SetActive(false);
        EnterNameUI.SetActive(false);
    }


    public void endScreen()
    {
        EndScreenUI.SetActive(true);
        minutes = PlayerPrefs.GetInt("minutes");
        seconds = PlayerPrefs.GetInt("seconds");
        score = PlayerPrefs.GetInt("Score");
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        scoreText.text = "X " + score;
    }

    public void EnterNameMenu()
    {
        EnterNameUI.SetActive(true);
    }

    public void EnterNameBackMenu()
    {
        EnterNameUI.SetActive(false);
    }
    public void lowHighScoreResult()
    {
        textField.text = "Data not Save! Low Score";
    }
    public void saveHighScoreResult()
    {
        textField.text = "Highscore Saved!";
    }
    public void replaceHighScoreResult()
    {
        textField.text = "Replaced Lowest Highscore";
        textField.fontSize = 17;
    }
}
