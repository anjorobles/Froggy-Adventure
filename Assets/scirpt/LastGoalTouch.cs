using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastGoalTouch : MonoBehaviour
{
    private bool isTouch = false;
    //public int scoreVal;
    private Animator anim;

    private ItemCollector itemCollector;
    private GameTimer gameTimer;

    private EndScreen EndScreen_;

    //private Rigidbody2D rb;

    private PlayerLife plLife;

    void Start()
    {
        anim = GetComponent<Animator>();
        itemCollector = FindObjectOfType<ItemCollector>();
        gameTimer = FindObjectOfType<GameTimer>();
        EndScreen_ = FindObjectOfType<EndScreen>();
        //rb = GetComponent<Rigidbody2D>();
        plLife = GameObject.Find("Player").GetComponent<PlayerLife>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isTouch)
        {
            GoalisTouchAnimation();
            FindObjectOfType<BackgroundMusic>().Goalmusic();
            Invoke("CompleteLevel", 2f);
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
        FindObjectOfType<BackgroundMusic>().EndScreenSound();
        EndScreen_.endScreen();
        plLife.rb.bodyType = RigidbodyType2D.Static;
        //SceneManager.LoadScene(5);
    }
  
}
