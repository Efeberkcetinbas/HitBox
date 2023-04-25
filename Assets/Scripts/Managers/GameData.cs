using UnityEngine;

[CreateAssetMenu(fileName = "New GameData", menuName = "Data/Game Data", order = 1)]
public class GameData : ScriptableObject
{
    public int coins = 0;
    public int score = 0;
    public int highScore=0;
    public int increaseScore=25;

    public float hitTimeUp=0;
    public float hitTimeDown=0;
    public float hitTimeLeft=0;
    public float hitTimeRight=0;
    public float hitTimeCenter=0;

    public bool timeIsUp=false;
    public bool timeIsDown=false;
    public bool timeIsLeft=false;
    public bool timeIsRight=false;
    public bool timeIsCenter=false;
    public bool isGameEnd=false;



}
