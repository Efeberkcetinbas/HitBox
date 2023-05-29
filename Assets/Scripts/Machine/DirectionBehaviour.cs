using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DirectionBehaviour : MonoBehaviour
{

    public List<Transform> directions=new List<Transform>();

    public CentralData centralData;
    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnUp,ChangeUpMat);
        EventManager.AddHandler(GameEvent.OnDown,ChangeDownMat);
        EventManager.AddHandler(GameEvent.OnLeft,ChangeLeftMat);
        EventManager.AddHandler(GameEvent.OnRight,ChangeRightMat);

        EventManager.AddHandler(GameEvent.OnResetUp,ResetUpMat);
        EventManager.AddHandler(GameEvent.OnResetDown,ResetDownMat);
        EventManager.AddHandler(GameEvent.OnResetLeft,ResetLeftMat);
        EventManager.AddHandler(GameEvent.OnResetRight,ResetRightMat);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnUp,ChangeUpMat);
        EventManager.RemoveHandler(GameEvent.OnDown,ChangeDownMat);
        EventManager.RemoveHandler(GameEvent.OnLeft,ChangeLeftMat);
        EventManager.RemoveHandler(GameEvent.OnRight,ChangeRightMat);

        EventManager.RemoveHandler(GameEvent.OnResetUp,ResetUpMat);
        EventManager.RemoveHandler(GameEvent.OnResetDown,ResetDownMat);
        EventManager.RemoveHandler(GameEvent.OnResetLeft,ResetLeftMat);
        EventManager.RemoveHandler(GameEvent.OnResetRight,ResetRightMat);
    }

    

    private void ChangeUpMat()
    {
        directions[0].GetComponent<Image>().color=Color.green;
        directions[0].transform.DOScale(Vector3.one*12/1000,0.1f);
    }

    private void ChangeDownMat()
    {
        directions[1].GetComponent<Image>().color=Color.green;
        directions[1].transform.DOScale(Vector3.one*12/1000,0.1f);
    }

    private void ChangeLeftMat()
    {
        directions[2].GetComponent<Image>().color=Color.green;
        directions[2].transform.DOScale(Vector3.one*12/1000,0.1f);
    }

    private void ChangeRightMat()
    {
        directions[3].GetComponent<Image>().color=Color.green;
        directions[3].transform.DOScale(Vector3.one*12/1000,0.1f);
    }


    private void ResetUpMat()
    {
        directions[0].GetComponent<Image>().color=Color.red;
        directions[0].transform.DOScale(Vector3.one/100,0.1f);
        centralData.upHit=false;

    }
    private void ResetDownMat()
    {
        directions[1].GetComponent<Image>().color=Color.red;
        directions[1].transform.DOScale(Vector3.one/100,0.1f);
        centralData.downHit=false;
    }

    private void ResetLeftMat()
    {
        directions[2].GetComponent<Image>().color=Color.red;
        directions[2].transform.DOScale(Vector3.one/100,0.1f);
        centralData.leftHit=false;
    }

    private void ResetRightMat()
    {
        directions[3].GetComponent<Image>().color=Color.red;
        directions[3].transform.DOScale(Vector3.one/100,0.1f);
        centralData.rightHit=false;
    }

   

}
