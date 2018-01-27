using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionUnit
{
    public GameObject npc;
    public NPCscript npcScript;

    public EmotionUnit(GameObject NPCobj)
    {
        npc = NPCobj;
        npcScript = npc.GetComponent<NPCscript>();
    }
}
