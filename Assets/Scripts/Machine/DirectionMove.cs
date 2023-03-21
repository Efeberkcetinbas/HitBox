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
    }

    private void DownMove()
    {
        Debug.Log("Signal Moves Down");
    }

    private void LeftMove()
    {
        Debug.Log("Signal Moves Left");
    }

    private void RightMove()
    {
        Debug.Log("Signal Moves Right");
    }
}
