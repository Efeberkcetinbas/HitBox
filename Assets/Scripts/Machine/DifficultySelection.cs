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

    public void SelectEasyOption()
    {
        MovePanel();
        levelUpManager.levelUpThreshold=3200;
        levelUpManager.scoreLevelUpThreshold=200;
        levelUpManager.roundLevelThreshold=3200;
        levelUpManager.shuffleLevelThreshold=600;
    }

    public void SelectNormalOption()
    {
        MovePanel();
        levelUpManager.levelUpThreshold=400;
        levelUpManager.scoreLevelUpThreshold=800;
        levelUpManager.roundLevelThreshold=400;
        levelUpManager.shuffleLevelThreshold=200;
    }

    public void SelectHardOption()
    {
        MovePanel();
        levelUpManager.levelUpThreshold=100;
        levelUpManager.scoreLevelUpThreshold=400;
        levelUpManager.roundLevelThreshold=100;
        levelUpManager.shuffleLevelThreshold=200;
    }

    private void MovePanel()
    {
        difficultyPanel.DOAnchorPos(new Vector2(0,-2500f),0.25f).OnComplete(()=>{
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
