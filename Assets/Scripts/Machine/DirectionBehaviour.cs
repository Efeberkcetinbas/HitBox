using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionBehaviour : MonoBehaviour
{
    [SerializeField] private Material White,Green;

    public List<Transform> directions=new List<Transform>();
    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnUp,ChangeUpMat);
        EventManager.AddHandler(GameEvent.OnDown,ChangeDownMat);
        EventManager.AddHandler(GameEvent.OnLeft,ChangeLeftMat);
        EventManager.AddHandler(GameEvent.OnRight,ChangeRightMat);
        EventManager.AddHandler(GameEvent.OnResetAll,ResetMat);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnUp,ChangeUpMat);
        EventManager.RemoveHandler(GameEvent.OnDown,ChangeDownMat);
        EventManager.RemoveHandler(GameEvent.OnLeft,ChangeLeftMat);
        EventManager.RemoveHandler(GameEvent.OnRight,ChangeRightMat);
        EventManager.RemoveHandler(GameEvent.OnResetAll,ResetMat);
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

    private void ResetMat()
    {
        for (int i = 0; i < directions.Count; i++)
        {
            directions[i].GetComponent<MeshRenderer>().material=White;
        }
    }
}
