using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using TMPro;
public class SandBagTrigger : Obstacable
{
    [SerializeField] private GameObject particleEffect;

    [SerializeField] private float z,old_z,duration;

    private Vector3 oldScale;
    
    [SerializeField] private Transform particlePos;
    [SerializeField] private Transform pointPos;


    [SerializeField] private GameObject increaseScorePrefab;

    [SerializeField] private GameData gameData;



    [SerializeField] private bool isLeft,isRight,isUp,isDown;
    


    private void Start() 
    {
        oldScale=transform.localScale;
    }
    internal override void DoAction(PlayerTrigger player)
    {
        transform.DOLocalMoveZ(z,duration);
        //transform.DOLocalRotate();
        transform.DOScale(oldScale/3f,duration);
        EventManager.Broadcast(GameEvent.OnTargetHit);
        Instantiate(particleEffect,particlePos.position,Quaternion.identity);
        StartCoinMove(gameObject);

        if(isLeft) EventManager.Broadcast(GameEvent.OnRivalHitLeft);
        if(isRight) EventManager.Broadcast(GameEvent.OnRivalHitRight);
        if(isUp) EventManager.Broadcast(GameEvent.OnRivalHitUp);
        if(isDown) EventManager.Broadcast(GameEvent.OnRivalHitDown);

        
    }

    internal override void StopAction(PlayerTrigger player)
    {
        Debug.Log("OUT");
        transform.DOScale(oldScale,duration);
        transform.DOLocalMoveZ(old_z,duration);
    }

    private void StartCoinMove(GameObject a)
    {
        GameObject coin=Instantiate(increaseScorePrefab,pointPos.transform.position,increaseScorePrefab.transform.rotation);
        coin.transform.DOLocalJump(coin.transform.localPosition,1,1,1,false);
        //coin.transform.DOScale(Vector3.zero,1.5f);
        coin.transform.GetChild(0).GetComponent<TextMeshPro>().text=" + " + gameData.increaseScore.ToString();
        coin.transform.GetChild(0).GetComponent<TextMeshPro>().DOFade(0,1.5f).OnComplete(()=>coin.transform.GetChild(0).gameObject.SetActive(false));
        Destroy(coin,2);
    }
}
