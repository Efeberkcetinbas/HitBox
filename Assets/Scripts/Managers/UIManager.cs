using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI score,highscore,endingScore;
    public TextMeshProUGUI roundText,endingRoundText;
    public RectTransform roundMenu;

    public GameData gameData;
    public PlayerData playerData;

    [Header("Progess Control")]
    [SerializeField] private Image progressImage;
    [SerializeField] private LevelUpManager levelUpManager;
    private int tempRoundNumber;
    private float amount;

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnUpdateUI, OnUIUpdate);
        EventManager.AddHandler(GameEvent.OnUpdateGameOverUI,OnUIGameOver);
        EventManager.AddHandler(GameEvent.OnNextRound,OnRoundUpdate);
        EventManager.AddHandler(GameEvent.OnTargetHit,OnHit);
    }
    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnUpdateUI, OnUIUpdate);
        EventManager.RemoveHandler(GameEvent.OnUpdateGameOverUI,OnUIGameOver);
        EventManager.RemoveHandler(GameEvent.OnNextRound,OnRoundUpdate);
        EventManager.RemoveHandler(GameEvent.OnTargetHit,OnHit);
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
            OnNextRound();
            roundText.SetText("Round " + gameData.roundNumber.ToString());
            StartCoroutine(GetBack());
        });
    }

    void OnNextRound()
    {
        progressImage.DOFillAmount(0,0.1f);
        tempRoundNumber=levelUpManager.roundLevelThreshold;
        Debug.Log(tempRoundNumber);
        amount=(float)gameData.score/levelUpManager.roundLevelThreshold;
    }

    void OnHit()
    {
        amount=(float)gameData.score/levelUpManager.roundLevelThreshold;
        Debug.Log("AMOUNT : " + amount);
        progressImage.DOFillAmount(amount,0.1f);
    }

    private IEnumerator GetBack()
    {
        yield return new WaitForSeconds(2);
        roundMenu.DOAnchorPos(new Vector3(-150,-250,0),0.25f);
    }
}
