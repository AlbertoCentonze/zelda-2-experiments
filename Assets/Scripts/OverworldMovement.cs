using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldMovement : MonoBehaviour
{
    private Rigidbody2D playerBody;
    [SerializeField] private float speed = 5f;
    Vector2 direction;

    void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        playerBody.MovePosition(playerBody.position + direction * speed * Time.fixedDeltaTime);
    }
}
