using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC_Manager : MonoBehaviour
{
    [Range(50, 1000)] public int baseHealth = 100;
    [Range(1, 100)] public int level = 5;
    public int health;
    public int healthMultiplier = 1;
    
    public enum approachEnum {Pacific, Friendly, Neutral, Hostile};
    public approachEnum approach = approachEnum.Pacific;
    public UnityEvent OnDial;

    private void Awake()
    {
        if (OnDial == null)
            OnDial = new UnityEvent();
    }

    private void Start()
    {
        health = ActualHealth(level, baseHealth, healthMultiplier);
    }

    private int ActualHealth(int level, int health, int multiplier)
    {
        int i = 0;

        while (i < level)
        {
            health += 10 * multiplier;
            i++;
        }

        return health;
    }

    private void Die()
    {
        //animation
        //giveExp
        Destroy(this.gameObject);
    }

    private void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }
}
