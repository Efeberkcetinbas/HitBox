using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI score,highscore,endingScore;
    public TextMeshProUGUI roundText,endingRoundText;
    public RectTransform roundMenu;


    public GameData gameData;
    public PlayerData playerData;

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnUpdateUI, OnUIUpdate);
        EventManager.AddHandler(GameEvent.OnUpdateGameOverUI,OnUIGameOver);
        EventManager.AddHandler(GameEvent.OnNextRound,OnRoundUpdate);
    }
    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnUpdateUI, OnUIUpdate);
        EventManager.RemoveHandler(GameEvent.OnUpdateGameOverUI,OnUIGameOver);
        EventManager.RemoveHandler(GameEvent.OnNextRound,OnRoundUpdate);
    }

    
    void OnUIUpdate()
    {
        score.SetText(gameData.score.ToString());
        score.transform.DOScale(new Vector3(1.5f,1.5f,1.5f),0.2f).OnComplete(()=>score.transform.DOScale(new Vector3(1,1f,1f),0.2f));
        //coin.SetText("x" + gameData.coins.ToString());
    }

    void OnUIGameOver()
    {
        score.SetText("");
        endingScore.SetText("Score : " + gameData.score.ToString());
        endingRoundText.SetText("Round: " + gameData.roundNumber.ToString());
        highscore.SetText("High Score : " + gameData.highScore.ToString());
    }

    void OnRoundUpdate()
    {
        roundMenu.DOAnchorPos(new Vector3(150,-250,0),0.25f).OnComplete(()=>{
            roundText.SetText("Round " + gameData.roundNumber.ToString());
            StartCoroutine(GetBack());
        });
    }

    private IEnumerator GetBack()
    {
        yield return new WaitForSeconds(2);
        roundMenu.DOAnchorPos(new Vector3(-150,-250,0),0.25f);
    }
}
