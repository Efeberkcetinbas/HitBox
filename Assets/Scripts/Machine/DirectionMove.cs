using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionMove : MonoBehaviour
{
    [Header("Directions")]
    public Transform Up;
    public Transform Down;
    public Transform Left;
    public Transform Right;
    public Transform Center;



    public CentralData centralData;
    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnUp,UpMove);
        EventManager.AddHandler(GameEvent.OnDown,DownMove);
        EventManager.AddHandler(GameEvent.OnLeft,LeftMove);
        EventManager.AddHandler(GameEvent.OnRight,RightMove);
        EventManager.AddHandler(GameEvent.OnCenter,CentralMove);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnUp,UpMove);
        EventManager.RemoveHandler(GameEvent.OnDown,DownMove);
        EventManager.RemoveHandler(GameEvent.OnLeft,LeftMove);
        EventManager.RemoveHandler(GameEvent.OnRight,RightMove);
        EventManager.RemoveHandler(GameEvent.OnCenter,CentralMove);
    }

    private void UpMove()
    {
        centralData.upHit=true;
        centralData.downHit=false;
        centralData.rightHit=false;
        centralData.leftHit=false;
        centralData.centralHit=false;
    }

    private void DownMove()
    {
        centralData.upHit=false;
        centralData.downHit=true;
        centralData.rightHit=false;
        centralData.leftHit=false;
        centralData.centralHit=false;
    }

    private void LeftMove()
    {
        centralData.upHit=false;
        centralData.downHit=false;
        centralData.rightHit=false;
        centralData.leftHit=true;
        centralData.centralHit=false;
    }

    private void RightMove()
    {
        centralData.upHit=false;
        centralData.downHit=false;
        centralData.rightHit=true;
        centralData.leftHit=false;
        centralData.centralHit=false;
    }

    private void CentralMove()
    {
        centralData.upHit=false;
        centralData.downHit=false;
        centralData.rightHit=false;
        centralData.leftHit=false;
        centralData.centralHit=true;
    }
}
