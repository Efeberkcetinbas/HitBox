using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ModManager : MonoBehaviour
{
    public GameData gameData;
    public PlayerData playerData;
    public ModData modData;
    
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject ChallengerMenu;
    [SerializeField] private GameObject LevelMenu;

    public void SelectChallengerMod()
    {
        MainMenu.transform.DOScale(Vector3.zero,0.5f).OnComplete(()=>{
            Selection(true,false);
        });
        
    }

    public void SelectLevelMod()
    {
        MainMenu.transform.DOScale(Vector3.zero,0.5f).OnComplete(()=>{
            Selection(false,true);
        });
    }

    private void Selection(bool challenge,bool level)
    {
        MainMenu.SetActive(false);
        gameData.isGameEnd=false;
        playerData.playerCanMove=true;
        modData.ChallengeMod=challenge;
        modData.LevelMod=level;
        ChallengerMenu.SetActive(challenge);
        LevelMenu.SetActive(level);
    }
}
