using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionBehaviour : MonoBehaviour
{
    //[SerializeField] private Image Red,Green;

    public List<Transform> directions=new List<Transform>();

    public CentralData centralData;
    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnUp,ChangeUpMat);
        EventManager.AddHandler(GameEvent.OnDown,ChangeDownMat);
        EventManager.AddHandler(GameEvent.OnLeft,ChangeLeftMat);
        EventManager.AddHandler(GameEvent.OnRight,ChangeRightMat);
        EventManager.AddHandler(GameEvent.OnCenter,ChangeCentralMat);

        EventManager.AddHandler(GameEvent.OnResetUp,ResetUpMat);
        EventManager.AddHandler(GameEvent.OnResetDown,ResetDownMat);
        EventManager.AddHandler(GameEvent.OnResetLeft,ResetLeftMat);
        EventManager.AddHandler(GameEvent.OnResetRight,ResetRightMat);
        EventManager.AddHandler(GameEvent.OnResetCenter,ResetCenterMat);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnUp,ChangeUpMat);
        EventManager.RemoveHandler(GameEvent.OnDown,ChangeDownMat);
        EventManager.RemoveHandler(GameEvent.OnLeft,ChangeLeftMat);
        EventManager.RemoveHandler(GameEvent.OnRight,ChangeRightMat);
        EventManager.RemoveHandler(GameEvent.OnCenter,ChangeCentralMat);

        EventManager.RemoveHandler(GameEvent.OnResetUp,ResetUpMat);
        EventManager.RemoveHandler(GameEvent.OnResetDown,ResetDownMat);
        EventManager.RemoveHandler(GameEvent.OnResetLeft,ResetLeftMat);
        EventManager.RemoveHandler(GameEvent.OnResetRight,ResetRightMat);
        EventManager.RemoveHandler(GameEvent.OnResetCenter,ResetCenterMat);
    }

    

    private void ChangeUpMat()
    {
        directions[0].GetComponent<Image>().color=Color.green;
    }

    private void ChangeDownMat()
    {
        directions[1].GetComponent<Image>().color=Color.green;
    }

    private void ChangeLeftMat()
    {
        directions[2].GetComponent<Image>().color=Color.green;
    }

    private void ChangeRightMat()
    {
        directions[3].GetComponent<Image>().color=Color.green;
    }

    private void ChangeCentralMat()
    {
        directions[4].GetComponent<Image>().color=Color.green;
    }

    private void ResetUpMat()
    {
        directions[0].GetComponent<Image>().color=Color.red;
        centralData.upHit=false;

    }
    private void ResetDownMat()
    {
        directions[1].GetComponent<Image>().color=Color.red;
        centralData.downHit=false;
    }

    private void ResetLeftMat()
    {
        directions[2].GetComponent<Image>().color=Color.red;
        centralData.leftHit=false;
    }

    private void ResetRightMat()
    {
        directions[3].GetComponent<Image>().color=Color.red;
        centralData.rightHit=false;
    }

    private void ResetCenterMat()
    {
        directions[4].GetComponent<Image>().color=Color.red;
        centralData.centralHit=false;
    }

}
