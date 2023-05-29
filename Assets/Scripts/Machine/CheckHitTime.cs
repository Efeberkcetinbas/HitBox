using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CheckHitTime : MonoBehaviour
{   
    public GameData gameData;
    
    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnUp,CreateUpObject);
        EventManager.AddHandler(GameEvent.OnDown,CreateDownObject);
        EventManager.AddHandler(GameEvent.OnLeft,CreateLeftObject);
        EventManager.AddHandler(GameEvent.OnRight,CreateRightObject);

        EventManager.AddHandler(GameEvent.OnPlayerUp,DestroyUpObject);
        EventManager.AddHandler(GameEvent.OnPlayerDown,DestroyDownObject);
        EventManager.AddHandler(GameEvent.OnPlayerLeft,DestroyLeftObject);
        EventManager.AddHandler(GameEvent.OnPlayerRight,DestroyRightObject);
        
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnUp,CreateUpObject);
        EventManager.RemoveHandler(GameEvent.OnDown,CreateDownObject);
        EventManager.RemoveHandler(GameEvent.OnLeft,CreateLeftObject);
        EventManager.RemoveHandler(GameEvent.OnRight,CreateRightObject);

        EventManager.RemoveHandler(GameEvent.OnPlayerUp,DestroyUpObject);
        EventManager.RemoveHandler(GameEvent.OnPlayerDown,DestroyDownObject);
        EventManager.RemoveHandler(GameEvent.OnPlayerLeft,DestroyLeftObject);
        EventManager.RemoveHandler(GameEvent.OnPlayerRight,DestroyRightObject);
    }

    void CreateUpObject()
    {
        gameData.timeIsUp=true;
    }
    void CreateDownObject()
    {
        gameData.timeIsDown=true;
    }  

    void CreateLeftObject()
    {
        gameData.timeIsLeft=true;
    }  

    void CreateRightObject()
    {
        gameData.timeIsRight=true;
    }  

   
    void DestroyUpObject()
    {
        gameData.timeIsUp=false;
        gameData.hitTimeUp=0;
    }

    void DestroyDownObject()
    {
        gameData.timeIsDown=false;
        gameData.hitTimeDown=0;
    }

    void DestroyLeftObject()
    {
        gameData.timeIsLeft=false;
        gameData.hitTimeLeft=0;
    }

    void DestroyRightObject()
    {
        gameData.timeIsRight=false;
        gameData.hitTimeRight=0;
    }

    



    
}
