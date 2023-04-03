using UnityEngine;

[CreateAssetMenu(fileName = "New CentralData", menuName = "Data/Central Data", order = 2)]
public class CentralData : ScriptableObject
{
    //Kademeli olarak azaltacak bir algoritma gerekli
    public float changeSignalTime;

    //fake red ' te vuramayiz
    public bool canHit;

    //order
    public bool upHit,downHit,leftHit,rightHit,centralHit;

    public bool playerUpHit,playerDownHit,playerLeftHit,playerRightHit,playerCentralHit;
}
