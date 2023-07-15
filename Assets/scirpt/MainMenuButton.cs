using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{

    private ShowHighScoreTable SHT;
    private EndScreen EndScreen_;

    private ItemCollector itemCollector;
    private GameTimer gameTimer;
    private PlayerLife playerLife;

     void Start()
    {
        itemCollector = FindObjectOfType<ItemCollector>();
        gameTimer = FindObjectOfType<GameTimer>();
        playerLife = FindObjectOfType<PlayerLife>();
        Debug.Log("MainMenuButton Start() called.");
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        itemCollector.ResetScore();
        gameTimer.ResetTime();
        playerLife.ResetLife();
    }

    private void checkInstances()
    {
        GameTimer[] gameTimer = FindObjectsOfType<GameTimer>();

        if (gameTimer.Length > 1)
        {
            Debug.Log("More than 1");
        }
        else if (gameTimer.Length == 1)
        {
            Debug.Log("Only 1");
        }
        else
        {
            Debug.Log("no instances");
        }

    }

    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
        itemCollector.ResetScore();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void saveButton()
    {
        EndScreen_ = FindObjectOfType<EndScreen>();
        EndScreen_.EnterNameMenu();
    }

    public void EnterNameBackButton()
    {
        EndScreen_ = FindObjectOfType<EndScreen>();
        EndScreen_.EnterNameBackMenu();
    }

    public void showHighScoreTable()
    {
       SHT = FindObjectOfType<ShowHighScoreTable>();
       SHT.showHighscoretable();
    }

    public void backHighScoreTable()
    {
        SHT = FindObjectOfType<ShowHighScoreTable>();
        SHT.backHT();
    }
}
