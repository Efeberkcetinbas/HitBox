using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    public GameData gameData;
    public CentralData centralData;
    public int levelUpThreshold;

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
    }


    public void OnDecreaseReaction()
    {
        if(centralData.changeSignalTime>0.25f)
        {
            centralData.changeSignalTime-=0.25f;
            //EventManager.Broadcast(GameEvent.OnDecreaseReactionTime);
        }
        

    }
}
