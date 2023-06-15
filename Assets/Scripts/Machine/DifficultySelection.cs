using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class DifficultySelection : MonoBehaviour
{
    [SerializeField] private RectTransform difficultyPanel;

    [SerializeField] private LevelUpManager levelUpManager;

    public GameData gameData;
    public PlayerData playerData;

    public void SelectNormalOption()
    {
        //3200,200,3200,600
        Options(levelUpManager,400,800,400,200);
        EventManager.Broadcast(GameEvent.OnNextRound);
    }

    public void SelectHardOption()
    {
        //400,800,400,200
        Options(levelUpManager,100,400,100,200);
        EventManager.Broadcast(GameEvent.OnNextRound);
    }

    public void SelectWorldClassOption()
    {
        //100,400,100,200
        Options(levelUpManager,100,200,100,50);
        EventManager.Broadcast(GameEvent.OnNextRound);
    }

    private void Options(LevelUpManager levelUpManager,int levelUpThreshold,int scoreLevelUpThreshold,int roundLevelThreshold,int shuffleLevelThreshold)
    {
        MovePanel();
        EventManager.Broadcast(GameEvent.OnButtonPressed);
        levelUpManager.levelUpThreshold=levelUpThreshold;
        levelUpManager.scoreLevelUpThreshold=scoreLevelUpThreshold;
        levelUpManager.roundLevelThreshold=roundLevelThreshold;
        levelUpManager.shuffleLevelThreshold=shuffleLevelThreshold;
    }

    private void MovePanel()
    {
        difficultyPanel.DOAnchorPos(new Vector2(0,-2500f),1f).OnComplete(()=>{
            EventManager.Broadcast(GameEvent.OnPanelChange);
            difficultyPanel.gameObject.SetActive(false);
            StartCoroutine(StartGame());
        });
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.5f);
        gameData.isGameEnd=false;
        playerData.playerCanMove=true;
    }
}
