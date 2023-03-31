using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip GameLoop,BuffMusic;
    public AudioClip HitSound,GameOverSound;

    AudioSource musicSource,effectSource;

    private void Start() {
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = GameLoop;
        //musicSource.Play();
        effectSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnTargetHit,OnHit);
        EventManager.AddHandler(GameEvent.OnGameOver,OnGameOver);
    }
    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnTargetHit,OnHit);
        EventManager.RemoveHandler(GameEvent.OnGameOver,OnGameOver);
    }

    void OnHit()
    {
        effectSource.PlayOneShot(HitSound);
    }

    void OnGameOver()
    {
        effectSource.PlayOneShot(GameOverSound);
    }



    

}
