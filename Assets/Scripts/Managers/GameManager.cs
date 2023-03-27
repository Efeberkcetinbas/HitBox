using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameData gameData;
    public PlayerData playerData;

    private void Start() {
        ClearData();
    }

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnIncreaseScore, OnIncreaseScore);
        EventManager.AddHandler(GameEvent.OnIncreaseGold,OnIncreaseGold);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnIncreaseScore, OnIncreaseScore);
        EventManager.RemoveHandler(GameEvent.OnIncreaseGold,OnIncreaseGold);
    }
    
    

    void OnIncreaseScore()
    {
        gameData.score += 50;
        CheckScore();
        EventManager.Broadcast(GameEvent.OnUpdateUI);
    }

    private void CheckScore()
    {
        if(gameData.score==500)
            EventManager.Broadcast(GameEvent.OnShuffle);
        //Effect
    }

    void OnIncreaseGold()
    {
        gameData.coins += 1;
        EventManager.Broadcast(GameEvent.OnUpdateUI);
    }
    void ClearData(){
        gameData.coins = 0;
        gameData.score = 0;
        playerData.playerCanMove=true;
    }
}
