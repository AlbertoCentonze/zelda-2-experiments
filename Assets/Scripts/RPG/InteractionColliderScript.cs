using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionColliderScript : MonoBehaviour
{
    public bool interaction = false;
    public NPC_Manager npc;
    public PlayerRPGCore playerData;

    private void Awake()
    {
        npc = GetComponentInParent<NPC_Manager>();
        playerData = GameObject.FindWithTag("Player").GetComponent<PlayerRPGCore>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("1");
        if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.tag == "Player" && !(playerData.busy))
        {
            npc.OnDial.Invoke();
        }
    }
}
