using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldMovement : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float speed = 5f; 

    void Awake()
    {
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == - 1)
        {
            player.position = new Vector3(speed * Time.deltaTime * Input.GetAxisRaw("Horizontal"), player.position.y, player.position.z);
        }
        else if (Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            player.position = new Vector3(player.position.x, speed * Time.deltaTime * Input.GetAxisRaw("Vertical"), player.position.z);
        }
    }
}
