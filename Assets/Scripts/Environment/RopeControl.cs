using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RopeControl : MonoBehaviour
{
    [SerializeField] private float swingPower;
    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnTargetHit,OnTargetHit);    
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnTargetHit,OnTargetHit);
    }

    private void OnTargetHit()
    {
        transform.DOPunchScale(Vector3.one*swingPower,0.2f,10,2);
    }
}
