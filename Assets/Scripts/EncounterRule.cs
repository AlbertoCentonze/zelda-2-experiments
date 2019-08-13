using UnityEngine;

[System.Serializable]

public class EncounterRule
{
    public enum zoneEnum { grass, desert, lava };
    public zoneEnum zone = zoneEnum.grass;
    public Enemy[] individualEnemies;
    public enum difficultyEnum { Automatic, Easy, Medium, Hard };
    public difficultyEnum difficulty = difficultyEnum.Automatic;
    private GameObject[] zoneEnemies;
}
