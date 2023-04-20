using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralControl : MonoBehaviour
{
    public CentralData centralData;
    public GameData gameData;

    public List<Transform> Directions=new List<Transform>();


    private int index;
    private float time;

    

    void Start()
    {
        index=Random.Range(0,Directions.Count);
        ActiveDirection();
    }

    void Update()
    {
        if(!gameData.isGameEnd)
        {
            time+=Time.deltaTime;
            if(time>centralData.changeSignalTime)
            {
                ChangeIndex();
                ActiveDirection();
                time=0;
            }

            if(gameData.timeIsUp)
            {
                gameData.hitTime+=Time.deltaTime;
                if(gameData.hitTime>centralData.reactionTime)
                {
                    Debug.Log("TIME IS UP BRO YOU LOST");
                    EventManager.Broadcast(GameEvent.OnGameOver);
                }
            }
        }
        
    }


    private int ChangeIndex()
    {
        var firstIndex=index;
        index=Random.Range(0,Directions.Count);

        if(index!=firstIndex)
            return index;

        else
            index=Random.Range(0,Directions.Count);
        
        return index;
    }

    private void ActiveDirection()
    {
        switch(index)
        {
            case 0:
                ActiveUp();
                break;

            case 1:
                ActiveDown();
                break;

            case 2:
                ActiveLeft();
                break;

            case 3:
                ActiveRight();
                break;
            case 4:
                ActiveCentral();
                break;

        }

    }

    private void ActiveUp()
    {
        EventManager.Broadcast(GameEvent.OnUp);
    }

    private void ActiveDown()
    {
        EventManager.Broadcast(GameEvent.OnDown);
    }

    private void ActiveLeft()
    {
        EventManager.Broadcast(GameEvent.OnLeft);
    }

    private void ActiveRight()
    {
        EventManager.Broadcast(GameEvent.OnRight);
    }

    private void ActiveCentral()
    {
        EventManager.Broadcast(GameEvent.OnCenter);
    }

    
   

    
}
