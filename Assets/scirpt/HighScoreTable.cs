using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;

    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;

    private HighScores highscores;

    private EndScreen endScreen;

    private void Awake()
    {
        entryTemplate.gameObject.SetActive(false);

        endScreen = FindObjectOfType<EndScreen>();

       // AddHighScoreEntry(32, "JULZ", 4, 12);

        //generate dummy list of highscore
      /* highScoreEntryList = new List<HighScoreEntry>()
        {
            new HighScoreEntry {score = 23, name = "JOJO", minutes = 4, seconds = 15},
            new HighScoreEntry {score = 12, name = "BEN", minutes = 7, seconds = 23},
            new HighScoreEntry {score = 9, name = "QWER", minutes = 11, seconds = 15},
            new HighScoreEntry {score = 7, name = "BVD", minutes = 3, seconds = 10},
            new HighScoreEntry {score = 17, name = "SDFG", minutes = 6, seconds = 07},
        };*/

        

        string jsonString = PlayerPrefs.GetString("highscoretable");
        highscores = JsonUtility.FromJson<HighScores>(jsonString);
        Debug.Log("Count: " + highscores.highscoreEntryList.Count);

        SortHighScores(highscores);

        highScoreEntryTransformList = new List<Transform>();

        

        foreach(HighScoreEntry highScoreEntry in highscores.highscoreEntryList)
        {
            CreatingHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
        }
        
       /* HighScores highscores = new HighScores {highscoreEntryList = highScoreEntryList};
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoretable", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("highscoretable"));*/

    }

    private void SortHighScores(HighScores highscores)
    {
        if (highscores != null && highscores.highscoreEntryList != null)
        {
            highscores.highscoreEntryList.Sort((a, b) =>
            {
                int scoreComparison = b.score.CompareTo(a.score);
                if (scoreComparison != 0)
                    return scoreComparison;

                TimeSpan aTime = PlayerTime(a);
                TimeSpan bTime = PlayerTime(b);
                int timeComparison = aTime.CompareTo(bTime);
                if (timeComparison != 0)
                    return timeComparison;

                return a.name.CompareTo(b.name);
            });
        }
    }


    private TimeSpan PlayerTime(HighScoreEntry highscoreEntry)
    {
        int minutes = highscoreEntry.minutes;   
        int seconds = highscoreEntry.seconds;

        return new TimeSpan(0, minutes, seconds);
    }

    private string FormatTime(TimeSpan time)
    {
        return string.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
    }

    private void CreatingHighScoreEntryTransform(HighScoreEntry highscoreEntry, Transform container, List<Transform>transformList)
    {
        float templateHeight = 30f;
        Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);

            int rank = transformList.Count + 1;
            string rankString;

            switch (rank)
            {
                default:
                    rankString = rank + "TH";
                    break;
                case 1:
                    rankString = "1ST";
                    break;
                case 2:
                    rankString = "2ND";
                    break;
                case 3:
                    rankString = "3RD";
                    break;
            }

            entryTransform.Find("rank text").GetComponent<Text>().text = rankString;
            
            int score = highscoreEntry.score;
            entryTransform.Find("score text").GetComponent<Text>().text = score.ToString();
            
            string name = highscoreEntry.name;
            entryTransform.Find("name text").GetComponent<Text>().text = name;
            
            TimeSpan randomTime = PlayerTime(highscoreEntry);

            entryTransform.Find("time text").GetComponent<Text>().text = FormatTime(randomTime);

            transformList.Add(entryTransform);
    }

    public void AddHighScoreEntry(int score, string name, int minutes, int seconds)
    {
        // Create high score entry
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = score, name = name, minutes = minutes, seconds = seconds };

        // Load saved high scores
        string jsonString = PlayerPrefs.GetString("highscoretable");
        HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);
        SortHighScores(highscores);
        
        if (highscores == null)
        {
            highscores = new HighScores();
        }
        if (highscores.highscoreEntryList == null)
        {
            highscores.highscoreEntryList = new List<HighScoreEntry>();
        }

       // highscores.highscoreEntryList.Add(highScoreEntry);
        // Checking the number of entries before adding a new high score
       if (highscores.highscoreEntryList.Count < 10)
        {
            // Add new entry
            highscores.highscoreEntryList.Add(highScoreEntry);
            Debug.Log("Sucessfully Added");
            Debug.Log(endScreen);
            endScreen.saveHighScoreResult();
        }
        else
        {
           HighScoreEntry lowestScore = highscores.highscoreEntryList[highscores.highscoreEntryList.Count - 1];

            int lowestIntScore = Convert.ToInt32(lowestScore.score);

            Debug.Log("Lowest: " + lowestIntScore);

            if (score > lowestIntScore)
            {
                // Replace the lowest score with the new entry
                highscores.highscoreEntryList[highscores.highscoreEntryList.Count - 1] = highScoreEntry;
                Debug.Log("Replace Complete");
                endScreen.replaceHighScoreResult();
                
            }
            else
            {
                Debug.Log("New score is not higher than the lowest score. Score not added.");
                endScreen.lowHighScoreResult();
            }
            
        }

        SortHighScores(highscores);

        // Save updated high scores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoretable", json);
        PlayerPrefs.Save();
    }


    private class HighScores
    {
        public List<HighScoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighScoreEntry
    {
        public int score;
        public string name;

        public int minutes;

        public int seconds;

    }

}
