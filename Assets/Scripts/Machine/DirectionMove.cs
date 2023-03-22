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
        Debug.Log("Signal Moves Up");
        centralData.upHit=true;
        centralData.downHit=false;
        centralData.rightHit=false;
        centralData.leftHit=false;
    }

    private void DownMove()
    {
        Debug.Log("Signal Moves Down");
        centralData.upHit=false;
        centralData.downHit=true;
        centralData.rightHit=false;
        centralData.leftHit=false;
    }

    private void LeftMove()
    {
        Debug.Log("Signal Moves Left");
        centralData.upHit=false;
        centralData.downHit=false;
        centralData.rightHit=false;
        centralData.leftHit=true;
    }

    private void RightMove()
    {
        Debug.Log("Signal Moves Right");
        centralData.upHit=false;
        centralData.downHit=false;
        centralData.rightHit=true;
        centralData.leftHit=false;
    }
}
