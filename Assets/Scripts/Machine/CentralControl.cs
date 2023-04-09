using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralControl : MonoBehaviour
{
    public CentralData centralData;

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
        time+=Time.deltaTime;
        if(time>centralData.changeSignalTime)
        {
            ChangeIndex();
            ActiveDirection();
            time=0;
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
        centralData.byHitUp=false;
        //StartCoroutine(CheckIfUpHitByPunch());
    }

    private void ActiveDown()
    {
        EventManager.Broadcast(GameEvent.OnDown);
        centralData.byHitDown=false;
        StartCoroutine(CheckIfDownHitByPunch());
    }

    private void ActiveLeft()
    {
        EventManager.Broadcast(GameEvent.OnLeft);
        centralData.byHitLeft=false;
        StartCoroutine(CheckIfLeftHitByPunch());
    }

    private void ActiveRight()
    {
        EventManager.Broadcast(GameEvent.OnRight);
        centralData.byHitRight=false;
        StartCoroutine(CheckIfRightHitByPunch());
    }

    private void ActiveCentral()
    {
        EventManager.Broadcast(GameEvent.OnCenter);
        centralData.byHitCenter=false;
        StartCoroutine(CheckIfCenterHitByPunch());
    }

    
    public IEnumerator CheckIfUpHitByPunch()
    {
        yield return new WaitForSeconds(centralData.reactionTime);
        /*if(!centralData.byHitUp)
        {
            Debug.Log("TIME IS UP");
            EventManager.Broadcast(GameEvent.OnGameOver);
        }*/
    }

    public IEnumerator CheckIfDownHitByPunch()
    {
        yield return new WaitForSeconds(centralData.reactionTime);
        /*if(!centralData.byHitDown)
        {
            Debug.Log("TIME IS UP");
            EventManager.Broadcast(GameEvent.OnGameOver);
        }*/
    }

    public IEnumerator CheckIfLeftHitByPunch()
    {
        yield return new WaitForSeconds(centralData.reactionTime);
        /*if(!centralData.byHitLeft)
        {
            Debug.Log("TIME IS UP");
            EventManager.Broadcast(GameEvent.OnGameOver);
        }*/
        
    }

    public IEnumerator CheckIfRightHitByPunch()
    {
        yield return new WaitForSeconds(centralData.reactionTime);
        /*if(!centralData.byHitRight)
        {
            Debug.Log("TIME IS UP");
            EventManager.Broadcast(GameEvent.OnGameOver);
        }*/
        
    }

    public IEnumerator CheckIfCenterHitByPunch()
    {
        yield return new WaitForSeconds(centralData.reactionTime);
        /*if(!centralData.byHitCenter)
        {
            Debug.Log("TIME IS UP");
            EventManager.Broadcast(GameEvent.OnGameOver);
        }*/
        
    }

    
}
