using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHighScoreTable : MonoBehaviour
{
    public GameObject HT;

     void Start()
     {
          HT.SetActive(false);
     }
     public void showHighscoretable()
     {
          Debug.Log("Click");
          HT.SetActive(true);
     }

     public void backHT()
     {
          HT.SetActive(false);
     }
     }
