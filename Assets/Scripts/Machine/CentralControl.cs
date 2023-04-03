using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralControl : MonoBehaviour
{
    public CentralData centralData;

    public List<Transform> Directions=new List<Transform>();


    private int index;
    private float time;
    

    /*private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnResetAll,ResetCentral);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnResetAll,ResetCentral);
    }*/

    void Start()
    {
        index=Random.Range(0,Directions.Count);
        //Debug.Log(index + " / " + Directions[index].name);
        ActiveDirection();
    }

    void Update()
    {
        //Buraya hic gerek kalmayacak
        time+=Time.deltaTime;
        if(time>centralData.changeSignalTime)
        {
            ChangeIndex();
            ActiveDirection();
            time=0;
        }
    }

    private void ResetCentral()
    {
        /*time=0;
        ChangeIndex();
        ActiveDirection();*/
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
