using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleEnv : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnNextRound,OnNextRound);
        
    }

    private void OnDisable() {
        EventManager.RemoveHandler(GameEvent.OnNextRound,OnNextRound);
    }

    private void OnNextRound()
    {
        particle.Play();
    }
}
