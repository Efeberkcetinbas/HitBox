using System.Collections;
using System.Collections.Generic;
using MoreMountains.NiceVibrations;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    public HapticTypes HapticType=HapticTypes.HeavyImpact;

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnTargetHit,OnHit);
    }

    private void OnDisable() 
    {        
        EventManager.RemoveHandler(GameEvent.OnTargetHit,OnHit);
    }

    private void OnHit()
    {
        MMVibrationManager.TransientHaptic(1,1);
    }

    
}
