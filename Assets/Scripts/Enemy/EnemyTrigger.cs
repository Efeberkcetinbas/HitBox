using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : Obstacable
{
    [SerializeField] private ParticleSystem hitParticle;

    [SerializeField] private int health;
    [SerializeField] private Animator animator;
    [SerializeField] private SkinnedMeshRenderer meshRenderer;
    internal override void DoAction(PlayerTrigger player)
    {
        health--;

        EventManager.Broadcast(GameEvent.OnEnemyHit);
        hitParticle.Play();

        if(health<=0)
        {
            meshRenderer.material.color=Color.grey;
            animator.SetTrigger("Hit");
        }
    }

    internal override void StopAction(PlayerTrigger player)
    {
        Debug.Log("YERE YIGILDI");
    }
}
