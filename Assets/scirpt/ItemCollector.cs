using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    private int orangeScore;

    [SerializeField] public Text orangetext;
    
    [SerializeField] private AudioSource collectSoundEffect;

    void Start()
    {
        LoadOrangeScore();
        OrangeText();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orange"))
        {
            collectSoundEffect.Play();
            orangeScore +=1;
            SaveScore();
            OrangeText();
           // OrangeText();
           // Debug.Log("trigger= " + isTrigger);
        }
    }


    public void OrangeText ()
    {
        orangetext.text = "x" + orangeScore;
    }
    
    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", orangeScore);
        PlayerPrefs.Save(); 
    }

    public void ResetScore()
    {
        orangeScore = 0;
        SaveScore();
        //OrangeText();
        Debug.Log("reset score");
        //orangetext.text = "x" + orangeScore;
    }

   private void LoadOrangeScore()
    {
        if (PlayerPrefs.HasKey("Score")) {
            orangeScore = PlayerPrefs.GetInt("Score");
        } else {
            orangeScore = 0;
        }
        //Debug.Log(PlayerPrefs.GetInt("Score"));
        // Debug.Log("score =  " + orangeScore);
    }

    
}
