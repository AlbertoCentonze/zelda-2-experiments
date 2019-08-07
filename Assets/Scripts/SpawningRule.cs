using UnityEngine;

[System.Serializable]
public class SpawningRule
{
    public GameObject[] objects;
    public int[] probability; //da settare uguale al numero di ogetti
    public enum difficultyEnum {Automatic, Easy, Medium, Hard};
    public difficultyEnum difficulty = difficultyEnum.Automatic;
}
