using UnityEngine;

[CreateAssetMenu(fileName = "New CentralData", menuName = "Data/Central Data", order = 2)]
public class CentralData : ScriptableObject
{
    //Kademeli olarak azaltacak bir algoritma gerekli
    public float changeSignalTime;


    //fake red ' te vuramayiz
    public float reactionTime;

    //order directions
    public bool upHit,downHit,leftHit,rightHit,centralHit;

    //player hit direction and order direction match
    public bool playerUpHit,playerDownHit,playerLeftHit,playerRightHit,playerCentralHit;

    //Check if player doesn't hit
    //public bool byHitUp,byHitDown,byHitLeft,byHitRight,byHitCenter;

}
