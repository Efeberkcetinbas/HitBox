using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CheckHitTime : MonoBehaviour
{   
    public GameData gameData;

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnUp,CreateAnObject);
        EventManager.AddHandler(GameEvent.OnDown,CreateAnObject);
        EventManager.AddHandler(GameEvent.OnLeft,CreateAnObject);
        EventManager.AddHandler(GameEvent.OnRight,CreateAnObject);
        EventManager.AddHandler(GameEvent.OnCenter,CreateAnObject);

        EventManager.AddHandler(GameEvent.OnPlayerUp,DestroyAnObject);
        EventManager.AddHandler(GameEvent.OnPlayerDown,DestroyAnObject);
        EventManager.AddHandler(GameEvent.OnPlayerLeft,DestroyAnObject);
        EventManager.AddHandler(GameEvent.OnPlayerRight,DestroyAnObject);
        EventManager.AddHandler(GameEvent.OnPlayerCenter,DestroyAnObject);
        
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnUp,CreateAnObject);
        EventManager.RemoveHandler(GameEvent.OnDown,CreateAnObject);
        EventManager.RemoveHandler(GameEvent.OnLeft,CreateAnObject);
        EventManager.RemoveHandler(GameEvent.OnRight,CreateAnObject);
        EventManager.RemoveHandler(GameEvent.OnCenter,CreateAnObject);

        EventManager.RemoveHandler(GameEvent.OnPlayerUp,DestroyAnObject);
        EventManager.RemoveHandler(GameEvent.OnPlayerDown,DestroyAnObject);
        EventManager.RemoveHandler(GameEvent.OnPlayerLeft,DestroyAnObject);
        EventManager.RemoveHandler(GameEvent.OnPlayerRight,DestroyAnObject);
        EventManager.RemoveHandler(GameEvent.OnPlayerCenter,DestroyAnObject);
    }

    void CreateAnObject()
    {
        gameData.timeIsUp=true;
    }  

    void DestroyAnObject()
    {
        gameData.timeIsUp=false;
        gameData.hitTime=0;
    }

    
}
