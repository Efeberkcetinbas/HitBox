using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameEvent
{
    OnIncreaseScore,
    OnIncreaseGold,
    OnTargetHit,
    OnUpdateUI,
    OnUpdateGameOverUI,
    OnUpdateGameOverManager,
    OnGameOver,
    OnNextRound,


    //Directions
    OnUp,
    OnDown,
    OnLeft,
    OnRight,

    //Player Directions
    OnPlayerUp,
    OnPlayerDown,
    OnPlayerLeft,
    OnPlayerRight,

    //Rival Hit Directions
    OnRivalHitUp,
    OnRivalHitDown,
    OnRivalHitLeft,
    OnRivalHitRight,

    //Resets
    OnResetUp,
    OnResetDown,
    OnResetLeft,
    OnResetRight,

    //Enemy
    OnEnemyHit,
    OnEnemyDead,

    //UI Sound
    OnButtonPressed,
    OnPanelChange,

    //Level Up
    OnShuffle,
    OnDecreaseReactionTime

}

public class EventManager 
{
    private static Dictionary<GameEvent,Action> eventTable = new Dictionary<GameEvent, Action>();
    
    private static Dictionary<GameEvent,Action<int>> IdEventTable=new Dictionary<GameEvent, Action<int>>();
    //2 parametre baglayacagimiz ile bagladigimiz

    
    public static void AddHandler(GameEvent gameEvent,Action action)
    {
        if(!eventTable.ContainsKey(gameEvent))
            eventTable[gameEvent]=action;
        else eventTable[gameEvent]+=action;
    }

    public static void RemoveHandler(GameEvent gameEvent,Action action)
    {
        if(eventTable[gameEvent]!=null)
            eventTable[gameEvent]-=action;
        if(eventTable[gameEvent]==null)
            eventTable.Remove(gameEvent);
    }

    public static void Broadcast(GameEvent gameEvent)
    {
        if(eventTable[gameEvent]!=null)
            eventTable[gameEvent]();
    }
    
}
