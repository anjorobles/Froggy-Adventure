using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveName : MonoBehaviour
{
    public TextMeshProUGUI textField;
    public TMP_InputField display;
    private string playerName;
    private bool buttonClicked = false;
    

    [SerializeField] private GameObject highscoreTableObject;
    [SerializeField] private Button SaveButton;
    private HighScoreTable highscoreTable;
    private int score, minutes, seconds;

    // Start is called before the first frame update
    void Start()
    {
        highscoreTable = highscoreTableObject.GetComponent<HighScoreTable>();
        SaveButton = SaveButton.GetComponent<Button>();
         Debug.Log("savename start()");
        
    }

    public void SavingName()
    {
        if(!buttonClicked)
        {
            PlayerPrefs.SetString("player_name", display.text);
            PlayerPrefs.Save();
            playerName = PlayerPrefs.GetString("player_name");
            score = PlayerPrefs.GetInt("Score");
            minutes = PlayerPrefs.GetInt("minutes");
            seconds = PlayerPrefs.GetInt("seconds");
            highscoreTable.AddHighScoreEntry(score, playerName, minutes, seconds);

            
            SaveButton.interactable = false;

            buttonClicked = true;
        }
       
        
    }

    
}
