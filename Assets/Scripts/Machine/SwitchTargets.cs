using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTargets : MonoBehaviour
{
    public List<Vector3> positions=new List<Vector3>();
    public List<Transform> targets= new List<Transform>();

    
    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnShuffle,Shuffling);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnShuffle,Shuffling);
    }

    void Shuffling()
    {
        targets.Shuffle(targets.Count);
        for (int i = 0; i < targets.Count; i++)
        {
            targets[i].localPosition=positions[i];
        }
    }
    
}
