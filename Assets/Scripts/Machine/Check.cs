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
            EventManager.Broadcast(GameEvent.OnIncreaseScore);
        else
            Debug.Log("FAILLLL");

        StartCoroutine(DoReset());
    }

    private void CheckingDown()
    {
        if(centralData.downHit && centralData.playerDownHit)
            EventManager.Broadcast(GameEvent.OnIncreaseScore);
        else
            Debug.Log("FAILLLL");

        StartCoroutine(DoReset());
    }

    private void CheckingLeft()
    {
        if(centralData.leftHit && centralData.playerLeftHit)
            EventManager.Broadcast(GameEvent.OnIncreaseScore);
        else
            Debug.Log("FAILLLL");


        StartCoroutine(DoReset());
    }

    private void CheckingRight()
    {
        if(centralData.rightHit && centralData.playerRightHit)
            EventManager.Broadcast(GameEvent.OnIncreaseScore);
        else
            Debug.Log("FAILLLL");
        
        StartCoroutine(DoReset());
    }


    private IEnumerator DoReset()
    {
        //Bu sureleri ortak bir surede tut. Ayri ayri karisir. Time Management gameData icinde
        yield return new WaitForSeconds(0.5f);
        playerData.playerCanMove=true;
        EventManager.Broadcast(GameEvent.OnResetAll);
    }
}
