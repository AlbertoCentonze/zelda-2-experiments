using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData //insert only bool, string, int and float
{
    public string playerName;
    public int level;

    public PlayerData(PlayerRPGCore player) //what is a constructor?
    {
        playerName = player.playerName;
        level = player.level;
    }
}
