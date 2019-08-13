using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCColliderScript : MonoBehaviour
{
    private NPCManager npc;
    private PlayerRPGCore playerData;

    private void Awake()
    {
        npc = GetComponentInParent<NPCManager>();
        playerData = GameObject.FindWithTag("Player").GetComponent<PlayerRPGCore>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.tag == "Player" && !(playerData.busy))
        {
            npc.OnDial.Invoke();
        }
    }
}
