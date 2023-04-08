using UnityEngine;

[CreateAssetMenu(fileName = "New GameData", menuName = "Data/Game Data", order = 1)]
public class GameData : ScriptableObject
{
    public int coins = 0;
    public int score = 0;
    public int highScore=0;



}
