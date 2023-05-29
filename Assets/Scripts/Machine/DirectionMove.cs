using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionMove : MonoBehaviour
{

    public CentralData centralData;
    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnUp,UpMove);
        EventManager.AddHandler(GameEvent.OnDown,DownMove);
        EventManager.AddHandler(GameEvent.OnLeft,LeftMove);
        EventManager.AddHandler(GameEvent.OnRight,RightMove);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnUp,UpMove);
        EventManager.RemoveHandler(GameEvent.OnDown,DownMove);
        EventManager.RemoveHandler(GameEvent.OnLeft,LeftMove);
        EventManager.RemoveHandler(GameEvent.OnRight,RightMove);
    }

    private void UpMove()
    {
        centralData.upHit=true;
    }

    private void DownMove()
    {
        centralData.downHit=true;
    }

    private void LeftMove()
    {
        centralData.leftHit=true;
    }

    private void RightMove()
    {
        centralData.rightHit=true;
    }
}
