using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public CentralData centralData;
    public PlayerData playerData;
    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnPlayerUp,CheckingUp);
        EventManager.AddHandler(GameEvent.OnPlayerDown,CheckingDown);
        EventManager.AddHandler(GameEvent.OnPlayerLeft,CheckingLeft);
        EventManager.AddHandler(GameEvent.OnPlayerRight,CheckingRight);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnPlayerUp,CheckingUp);
        EventManager.RemoveHandler(GameEvent.OnPlayerDown,CheckingDown);
        EventManager.RemoveHandler(GameEvent.OnPlayerLeft,CheckingLeft);
        EventManager.RemoveHandler(GameEvent.OnPlayerRight,CheckingRight);
    }

    private void CheckingUp()
    {
        if(centralData.upHit && centralData.playerUpHit)
        {
            EventManager.Broadcast(GameEvent.OnIncreaseScore);
            EventManager.Broadcast(GameEvent.OnResetUp);
            playerData.playerCanMove=true;
        }
        else
            EventManager.Broadcast(GameEvent.OnGameOver);

    }

    private void CheckingDown()
    {
        if(centralData.downHit && centralData.playerDownHit)
        {
            EventManager.Broadcast(GameEvent.OnIncreaseScore);
            EventManager.Broadcast(GameEvent.OnResetDown);
            playerData.playerCanMove=true;
        }
        else
            EventManager.Broadcast(GameEvent.OnGameOver);

    }

    private void CheckingLeft()
    {
        if(centralData.leftHit && centralData.playerLeftHit)
        {
            EventManager.Broadcast(GameEvent.OnIncreaseScore);
            EventManager.Broadcast(GameEvent.OnResetLeft);
            playerData.playerCanMove=true;
        }
        else
            EventManager.Broadcast(GameEvent.OnGameOver);


    }

    private void CheckingRight()
    {
        if(centralData.rightHit && centralData.playerRightHit)
        {
            EventManager.Broadcast(GameEvent.OnIncreaseScore);
            EventManager.Broadcast(GameEvent.OnResetRight);
            playerData.playerCanMove=true;
        }
        else
            EventManager.Broadcast(GameEvent.OnGameOver);
        
    }

}
