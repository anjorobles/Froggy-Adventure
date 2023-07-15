using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    public Rigidbody2D rb;
    private Vector3 respawnPoint;

    private int froggyLife;

    public bool restartingToLevelOne;

    private bool FroggyIsDead = false;
    
    public RespawnTime respawnTime;
    private ItemCollector itemCollector;
    private GameTimer gameTimer;

    public GameOverScreen gameOver;

    [SerializeField] private AudioSource reviveSoundEffect;
    [SerializeField] private GameObject FallDetector;

    [SerializeField] private Text froggyLifeText;

    private void Start()
    {
        
        itemCollector = FindObjectOfType<ItemCollector>();
        gameTimer = FindObjectOfType<GameTimer>();

        loadFroggyLife();
        checkLifeNumber();
        Debug.Log("plife start()");
        Debug.Log("life= " + froggyLife);
        Debug.Log("restart= " + restartingToLevelOne);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        //froggyLife = 3;
        
    }

    private void Update()
    {
        FallDetector.transform.position = new Vector2 (transform.position.x, FallDetector.transform.position.y);
        SetLifeText();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
            FindObjectOfType<BackgroundMusic>().Deathmusic();
            if (froggyLife != 0)
            {
                StartCoroutine (RestartLevel());
                itemCollector.ResetScore();
                gameTimer.StopTimer();
            }else{
                gameTimer.StopTimer();
                gameTimer.ResetTime();
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FallDetector"))
        {
            Die();
            FindObjectOfType<BackgroundMusic>().Deathmusic();
            if (froggyLife != 0)
            {
                StartCoroutine (RestartLevel());
                itemCollector.ResetScore();
                gameTimer.StopTimer();
            }else{
                gameTimer.StopTimer();
                gameTimer.ResetTime();
            }

            
            
        }
    }

    private void Die()
    {
            //checkLifeNumber();
            MinusLifePoints();
            saveFroggyLife();
            transform.Find("BGM");
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("death");

           if(froggyLife > 0 && !FroggyIsDead)
            {
                respawnTime.StartRespawnTime();
            }

            if (froggyLife <= 0 && !FroggyIsDead)
            {
                FroggyIsDead = true;
                gameOver.gameOver();
                //showGameOverScreen();
            }
            
    }
    private void saveFroggyLife()
    {
        PlayerPrefs.SetInt("FroggyLife", froggyLife);
        PlayerPrefs.Save();
    }

    public void ResetLife()
    {
        froggyLife = 0;
        saveFroggyLife();
        SetLifeText();
        Debug.Log("Life reset");
    }

    private void loadFroggyLife()
    {
        if (PlayerPrefs.HasKey("FroggyLife")) {
            froggyLife = PlayerPrefs.GetInt("FroggyLife");
        } else {
            froggyLife = 3;
        }
    }

    private void checkLifeNumber()
    {
        if (froggyLife <= 0)
        {
            froggyLife = 3;
        }
       
    }

    private void MinusLifePoints()
    {
        if (froggyLife > 0)
        {
            froggyLife = froggyLife-1;
        }
        
    }

    private IEnumerator RestartLevel()
    {
        saveFroggyLife();

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestartToLevelOne()
    {
        SceneManager.LoadScene(0);
    }

    private void SetLifeText()
    {
        froggyLifeText.text = "x" + froggyLife;
    }

}
