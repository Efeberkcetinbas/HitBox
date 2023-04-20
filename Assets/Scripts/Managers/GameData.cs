using UnityEngine;

[CreateAssetMenu(fileName = "New GameData", menuName = "Data/Game Data", order = 1)]
public class GameData : ScriptableObject
{
    public int coins = 0;
    public int score = 0;
    public int highScore=0;
    public int increaseScore=25;

    public float hitTime=0;

    public bool timeIsUp=false;
    public bool isGameEnd=false;



}
