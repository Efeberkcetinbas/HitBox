using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SandBagTrigger : Obstacable
{
    [SerializeField] private GameObject particleEffect;

    [SerializeField] private float z,old_z,duration;

    private Vector3 oldScale;
    
    [SerializeField] private Transform particlePos;

    private void Start() 
    {
        oldScale=transform.localScale;
    }
    internal override void DoAction(PlayerTrigger player)
    {
        transform.DOLocalMoveZ(z,duration);
        transform.DOScale(oldScale/3f,duration);
        EventManager.Broadcast(GameEvent.OnTargetHit);
        Instantiate(particleEffect,particlePos.position,Quaternion.identity);
        Debug.Log("WORK IS");
    }

    internal override void StopAction(PlayerTrigger player)
    {
        transform.DOScale(oldScale,duration);
        transform.DOLocalMoveZ(old_z,duration);
    }
}
