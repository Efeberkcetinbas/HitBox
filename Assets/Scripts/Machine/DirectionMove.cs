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
        //StartCoroutine(ResetHit(0));
    }

    private void DownMove()
    {
        centralData.downHit=true;
        //StartCoroutine(ResetHit(1));
    }

    private void LeftMove()
    {
        centralData.leftHit=true;
        //StartCoroutine(ResetHit(2));
    }

    private void RightMove()
    {
        centralData.rightHit=true;
        //StartCoroutine(ResetHit(3));
    }

    private void CentralMove()
    {
        centralData.centralHit=true;
        //StartCoroutine(ResetHit(4));
    }


    private IEnumerator ResetHit(int index)
    {
        yield return new WaitForSeconds(centralData.reactionTime);
        switch(index)
        {
            case 0:
                centralData.upHit=false;
                EventManager.Broadcast(GameEvent.OnResetUp);
                break;
            case 1:
                centralData.downHit=false;
                EventManager.Broadcast(GameEvent.OnResetDown);
                break;
            case 2:
                centralData.leftHit=false;
                EventManager.Broadcast(GameEvent.OnResetLeft);
                break;
            case 3:
                centralData.rightHit=false;
                EventManager.Broadcast(GameEvent.OnResetRight);
                break;
            case 4:
                centralData.centralHit=false;
                EventManager.Broadcast(GameEvent.OnResetCenter);
                break;
            
        }
    }
}
