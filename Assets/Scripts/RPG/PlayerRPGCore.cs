using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRPGCore : MonoBehaviour
{
    public string name;
    public int level;
    public int actualHealth;
    [HideInInspector] public int maxHealth = 100;
    public int healthIncreaseMultiplier = 1;
    [HideInInspector] public bool busy = false;
    [HideInInspector] public int xp;


    private void Start()
    {
        actualHealth = maxHealth;
    }

    private void Update()
    {
        if (xp == 100)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        xp = 0;
        maxHealth += 10 * healthIncreaseMultiplier;
        actualHealth = maxHealth;
        Debug.Log(name + "reached level" + level);
    }
}
