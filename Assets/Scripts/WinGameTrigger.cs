using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameTrigger : MonoBehaviour
{
    public AudioSource mtnJingle;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.instance.isGameActive)
        {
            Debug.Log("Player entered WINNING trigger.");
            StopAllOtherAudio();
            GameManager.instance.EndGame();
            
            GameTimer gameTimer = FindObjectOfType<GameTimer>();
            if (gameTimer != null)
            {
                gameTimer.StopTimer();
            }

            mtnJingle.Play();
        }
    }

    void StopAllOtherAudio()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in allAudioSources)
        {
            if (audioSource != mtnJingle && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

}
