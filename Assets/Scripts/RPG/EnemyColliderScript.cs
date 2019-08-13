using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderScript : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private Rigidbody2D enemyBody;

    private PlayerRPGCore player;
    private EnemyManager enemy;

    private void Awake()
    {
        playerBody = GameObject.Find("Player2D").GetComponent<Rigidbody2D>();
        enemyBody = GetComponentInParent<Rigidbody2D>();

        player = GameObject.Find("Player2D").GetComponent<PlayerRPGCore>();
        enemy = GetComponentInParent<EnemyManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.actualHealth -= enemy.collisionDamage;
            playerBody.AddForce(-Vector2.right * GameObject.Find("Player2D").GetComponent<Transform>().localScale.x * 15, ForceMode2D.Impulse);
            enemyBody.AddForce(Vector2.right * GameObject.Find("Player2D").GetComponent<Transform>().localScale.x * 2, ForceMode2D.Impulse);
        }
        
    }
}
