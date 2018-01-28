using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionUnit
{
    public GameObject npc;
    public NPCscript npcScript;
    public PlayerMvm leader;

    public EmotionUnit(GameObject NPCobj, PlayerMvm player)
    {
        npc = NPCobj;
        npcScript = npc.GetComponent<NPCscript>();
        leader = player;
    }
}
