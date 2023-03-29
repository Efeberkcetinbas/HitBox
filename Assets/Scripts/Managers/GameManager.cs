using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameData gameData;
    public PlayerData playerData;
    public CentralData centralData;

    [SerializeField] private GameObject FailPanel;
    [SerializeField] private Ease ease;


    private void Awake() 
    {
        ClearData();
    }

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnIncreaseScore, OnIncreaseScore);
        EventManager.AddHandler(GameEvent.OnIncreaseGold,OnIncreaseGold);
        EventManager.AddHandler(GameEvent.OnUpdateGameOverManager,OnGameOver);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnIncreaseScore, OnIncreaseScore);
        EventManager.RemoveHandler(GameEvent.OnIncreaseGold,OnIncreaseGold);
        EventManager.RemoveHandler(GameEvent.OnUpdateGameOverManager,OnGameOver);
    }
    
    void OnGameOver()
    {
        FailPanel.SetActive(true);
        FailPanel.transform.DOScale(Vector3.one,1f).SetEase(ease);
        playerData.playerCanMove=false;

        if(gameData.score>gameData.highScore) gameData.highScore=gameData.score;

        EventManager.Broadcast(GameEvent.OnUpdateGameOverUI);
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
        centralData.upHit=false;
        centralData.downHit=false;
        centralData.leftHit=false;
        centralData.rightHit=false;
        centralData.centralHit=false;

    }

    public void GameRestart()
    {
        SceneManager.LoadScene(0);
    }
}
