using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerData data;

    

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnTargetHit, OnTargetHit);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnTargetHit, OnTargetHit);
    }

    private void Start()
    {
        ClearData();
    }
    

    void OnTargetHit()
    {
        Debug.Log("Target Hit");
    }
   

   

    private void ClearData(){
        data.isInvulnerable = false;
        data.speed = 0;
    }
}
