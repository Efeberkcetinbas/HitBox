using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    public GameData gameData;
    public CentralData centralData;
    public int levelUpThreshold;
    public int scoreLevelUpThreshold;

    private void Start() 
    {
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

    }


    private void OnDecreaseReaction()
    {
        if(centralData.changeSignalTime>0.25f)
        {
            centralData.changeSignalTime-=0.25f;
            //EventManager.Broadcast(GameEvent.OnDecreaseReactionTime);
            EventManager.Broadcast(GameEvent.OnShuffle);
        }
    }

    private void OnIncreaseScoreAmount()
    {
        if(gameData.increaseScore<100)
            gameData.increaseScore+=25;
    }

    
}
