using UnityEngine;

[CreateAssetMenu(fileName = "New CentralData", menuName = "Data/Central Data", order = 2)]
public class CentralData : ScriptableObject
{
    public float turningSpeed;
    public float changeSignalTime;

    //fake red ' te vuramayiz
    public bool canHit;
}
