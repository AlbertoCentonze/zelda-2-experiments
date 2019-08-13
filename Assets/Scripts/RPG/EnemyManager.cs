using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private PlayerRPGCore player;
    private Rigidbody2D body;

    [Range(1, 100)] public int level = 5;
    [Range(50, 1000)] public int maxHealth = 100;
    public int actualHealth;
    private int healthIncrease;
    private int damageReceived;
    public int collisionDamage = 20;

    private void Awake()
    {
        player = GameObject.Find("Player2D").GetComponent<PlayerRPGCore>();
        body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        healthIncrease = maxHealth / 10;
        maxHealth = ActualHealth(level, maxHealth, healthIncrease);
        actualHealth = maxHealth;
        damageReceived = player.damage;
    }

    private int ActualHealth(int level, int health, int increaseFactor)
    {
        int i = 0;

        while (i < level)
        {
            health += increaseFactor;
            i++;
        }

        return health;
    }

    private void Die()
    {
        //animation
        player.xp += GiveXp(level);
        Destroy(this.gameObject);
    }

    private void Update()
    {
        if (actualHealth <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sword")
        {
            body.AddForce(Vector2.right * damageReceived * 0.1f * GameObject.Find("Player2D").GetComponent<Transform>().localScale.x, ForceMode2D.Impulse);
            actualHealth -= (damageReceived / 2);
        }

        
    }

    private int GiveXp(int level)
    {
        int xp = level * 20;
        return xp;
    }
}
