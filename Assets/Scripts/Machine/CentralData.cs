using UnityEngine;

[CreateAssetMenu(fileName = "New CentralData", menuName = "Data/Central Data", order = 2)]
public class CentralData : ScriptableObject
{
    public float turningSpeed;
    public float changeSignalTime;

    //fake red ' te vuramayiz
    public bool canHit;

    //order
    public bool upHit,downHit,leftHit,rightHit;

    public bool playerUpHit,playerDownHit,playerLeftHit,playerRightHit;
}
