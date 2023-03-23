using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SandBagTrigger : Obstacable
{
    [SerializeField] private GameObject particleEffect;

    
    internal override void DoAction(PlayerTrigger player)
    {
        transform.DOLocalMoveZ(0.3f,0.2f);
        EventManager.Broadcast(GameEvent.OnTargetHit);
        Instantiate(particleEffect,transform.position,Quaternion.identity);
    }

    internal override void StopAction(PlayerTrigger player)
    {
        transform.DOLocalMoveZ(-0.1f,0.5f);
    }
}
