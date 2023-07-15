using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal_touch : MonoBehaviour
{
    private bool isTouch = false;
    public int scoreVal;
    private Animator anim;

    private ItemCollector itemCollector;
    private GameTimer gameTimer;

    private LevelLoader levelLoader;

    void Start()
    {
        anim = GetComponent<Animator>();
        itemCollector = FindObjectOfType<ItemCollector>();
        gameTimer = FindObjectOfType<GameTimer>();
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isTouch)
        {
            GoalisTouchAnimation();
            FindObjectOfType<BackgroundMusic>().Goalmusic();
            Invoke("CompleteLevel", 1f);
            gameTimer.StopTimer();
        }
    }

    private void GoalisTouchAnimation()
    {
        transform.Find("BGM");
        isTouch = true;
        anim.SetBool("isTouch", true);  
        GetComponent<Collider2D>().enabled = false;
    }

    private void CompleteLevel()
    {
        itemCollector.SaveScore();
        levelLoader.LoadNextLevel();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
  
}
