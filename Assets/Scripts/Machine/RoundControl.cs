using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundControl : MonoBehaviour
{

    [SerializeField] private Image RoundObject;
    [SerializeField] private List<Color> colors=new List<Color>();

    private int index;

    private void OnEnable() 
    {
        EventManager.AddHandler(GameEvent.OnNextRound,OnChangeColor);
    }

    private void OnDisable() 
    {
        EventManager.RemoveHandler(GameEvent.OnNextRound,OnChangeColor);
    }

    private void OnChangeColor()
    {
        if(index<colors.Count-1)
        {
            index++;
            RoundObject.color=colors[index];
        }
        
    }
    
}
