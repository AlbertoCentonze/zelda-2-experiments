using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRPGCore : MonoBehaviour
{
    public string playerName;
    public int level;
    public int actualHealth;
    public int maxHealth = 100;
    private int healthIncrease;
    public int damage = 50;
    public int damageIncreaseMultiplier = 1;
    [HideInInspector] public bool busy = false;
    public int xp;

    private void Start()
    {
        actualHealth = maxHealth;
        healthIncrease = maxHealth / 10;
    }

    private void Update()
    {
        if (xp == 100)
        {
            LevelUp();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Load();
        }
    }

    private void LevelUp()
    {
        level++;
        xp = 0;
        maxHealth += healthIncrease;
        actualHealth = maxHealth;
        damage += 10;
        Debug.Log(playerName + " reached level " + level);
    }

    private void Save()
    {
        SaveSystem.SavePlayer(this);
    }

    private void Load()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        playerName = data.playerName;
        level = data.level;
    }
}
