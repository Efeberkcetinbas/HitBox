using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchBagColor : MonoBehaviour
{

    [SerializeField] private Material Red,Green;
    public List<Transform> directions=new List<Transform>();
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
        directions[0].GetComponent<MeshRenderer>().material=Green;
    }

    private void ChangeDownMat()
    {
        directions[1].GetComponent<MeshRenderer>().material=Green;
    }

    private void ChangeLeftMat()
    {
        directions[2].GetComponent<MeshRenderer>().material=Green;
    }

    private void ChangeRightMat()
    {
        directions[3].GetComponent<MeshRenderer>().material=Green;
    }

    private void ChangeCentralMat()
    {
        directions[4].GetComponent<MeshRenderer>().material=Green;
    }

    private void ResetUpMat()
    {
        directions[0].GetComponent<MeshRenderer>().material=Red;

    }
    private void ResetDownMat()
    {
        directions[1].GetComponent<MeshRenderer>().material=Red;
    }

    private void ResetLeftMat()
    {
        directions[2].GetComponent<MeshRenderer>().material=Red;
    }

    private void ResetRightMat()
    {
        directions[3].GetComponent<MeshRenderer>().material=Red;
    }

    private void ResetCenterMat()
    {
        directions[4].GetComponent<MeshRenderer>().material=Red;
    }
}
