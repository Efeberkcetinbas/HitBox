using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ModManager : MonoBehaviour
{
    public GameData gameData;
    public PlayerData playerData;
    public ModData modData;
    
    
    [SerializeField] private RectTransform MainMenu;
    [SerializeField] private RectTransform ChallengerMenu;
    [SerializeField] private RectTransform LevelMenu;

    [SerializeField] private GameObject ChallengerMod;
    [SerializeField] private GameObject LevelMod;

    [Header("Anchor")]
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float challengeX;
    [SerializeField] private float challengeY;
    [SerializeField] private float levelX;
    [SerializeField] private float levelY;
    public void SelectChallengerMod()
    {
        EventManager.Broadcast(GameEvent.OnPanelChange);
        MainMenu.DOAnchorPos(new Vector2(x,y),1f).OnComplete(()=>{
            //ChallengerMenu.gameObject.SetActive(true);
            //Selection(true,false); 
            ChallengerMenu.DOAnchorPos(new Vector2(challengeX,challengeY),1f).OnComplete(()=>{
                ChallengerMod.SetActive(true);
            });
            
        });
        
    }

    public void SelectLevelMod()
    {
        EventManager.Broadcast(GameEvent.OnPanelChange);
        MainMenu.DOAnchorPos(new Vector2(x,y),1f).OnComplete(()=>{
            //Selection(false,true);
            LevelMenu.DOAnchorPos(new Vector2(challengeX,challengeY),1f).OnComplete(()=>{
                Common();
            });
        });
        
    }

    private void Selection(bool challenge,bool level)
    {
        //MainMenu.gameObject.SetActive(false);
        modData.ChallengeMod=challenge;
        modData.LevelMod=level;
        LevelMod.SetActive(level);
        ChallengerMod.SetActive(challenge);
        //ChallengerMenu.gameObject.SetActive(challenge);
        //LevelMenu.gameObject.SetActive(level);
    }

    private void Common()
    {
        gameData.isGameEnd=false;
        playerData.playerCanMove=true;
    }
}
