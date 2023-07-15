using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] public AudioSource levelmusic;
    [SerializeField] public AudioSource deathmusic;
    [SerializeField] public AudioSource goalmusic;
    [SerializeField] public AudioSource sawsound;
    [SerializeField] public AudioSource sawsound2;
    [SerializeField] public AudioSource sawsound3;

    [SerializeField] public AudioSource EndSceneSound;
    public bool levelSong = true;
    public bool deathSong = false;

    public bool goalSong = false;

    public bool endScreenSong = false;
    
    
    public void Levelmusic()
    {
        levelSong = true;
        deathSong = false;
        endScreenSong = false;
        levelmusic.Play();
    }

    public void Deathmusic()
    {
        if(levelmusic.isPlaying)
        {   
            levelSong = false;
            levelmusic.Stop();
            sawsound.Stop();
            sawsound2.Stop();
            sawsound3.Stop();
        }
        if (!deathmusic.isPlaying && deathSong == false)
        {
            deathmusic.Play();
            deathSong = true;
        }
    }

    public void Goalmusic()
    {
        if(levelmusic.isPlaying)
        {   
            levelSong = false;
            levelmusic.Stop();
        }
        if (!goalmusic.isPlaying && deathSong == false)
        {
            goalmusic.Play();
            goalSong = true;
        }
    }
    
    public void EndScreenSound()
    {
         if(levelmusic.isPlaying)
        {   
            levelSong = false;
            levelmusic.Stop();
        }
        if (!EndSceneSound.isPlaying && deathSong == false)
        {
            EndSceneSound.Play();
            endScreenSong = true;
        }
    }
}
