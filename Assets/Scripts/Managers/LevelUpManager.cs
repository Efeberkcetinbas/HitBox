using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    public GameData gameData;
    public CentralData centralData;
    public int levelUpThreshold;
    public int scoreLevelUpThreshold;
    public int roundLevelThreshold;
    public int shuffleLevelThreshold;

    private void Start() 
    {
        IncreaseRound();
        InvokeRepeating("CheckScore",1,1);
    }

    private void CheckScore()
    {
        if(gameData.score>=levelUpThreshold)
        {
            OnDecreaseReaction();
            levelUpThreshold*=2;
        }

        if(gameData.score>=scoreLevelUpThreshold)
        {
            OnIncreaseScoreAmount();
            scoreLevelUpThreshold*=2;
        }

        if(gameData.score>=roundLevelThreshold)
        {
            IncreaseRound();
            roundLevelThreshold+=roundLevelThreshold;
        }

        if(gameData.score>=shuffleLevelThreshold)
        {
            EventManager.Broadcast(GameEvent.OnShuffle);
            shuffleLevelThreshold*=2;
        }

    }

    private void IncreaseRound()
    {
        gameData.roundNumber+=1;
        EventManager.Broadcast(GameEvent.OnNextRound);
    }


    private void OnDecreaseReaction()
    {
        if(centralData.changeSignalTime>0.4f)
        {
            centralData.changeSignalTime-=0.2f;
            //EventManager.Broadcast(GameEvent.OnDecreaseReactionTime);
            EventManager.Broadcast(GameEvent.OnShuffle);
        }
    }

    private void OnIncreaseScoreAmount()
    {
        if(gameData.increaseScore<200)
            gameData.increaseScore+=25;
    }

    

    
}
