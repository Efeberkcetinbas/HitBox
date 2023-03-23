using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTargets : MonoBehaviour
{
    // 5 tane pos var 
    //Targetlari birbirlerinin yerine switch ediyoruz ilerledikce puan daha da zorlastirmak icin.

    public List<Vector3> positions=new List<Vector3>();
    public List<Transform> targets= new List<Transform>();



    private void Start() 
    {
        targets.Shuffle(targets.Count);
        for (int i = 0; i < targets.Count; i++)
        {
            targets[i].localPosition=positions[i];
        }
    }


    //Level Up Handler ile tetiklersin
    
}
