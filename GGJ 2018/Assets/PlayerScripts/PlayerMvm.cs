using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMvm : MonoBehaviour {

    public GameManagerScript ManagerScript;

    public GameObject NPCprefab;

    public float Base_velocity;
    private Rigidbody2D rigiBody;
    public bool Attack;
    public string Team;
    public float Speed;
    public float attackRng;
    public int health;

    public List<EmotionUnit> EmotionArmy;

	void Start ()
    {
        Attack = false;

        // Spawn Emotion Army
        EmotionArmy = new List<EmotionUnit>();

        for (int i = 0; i < 5; i++)
        {
            Vector3 randPos = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), -1);
            GameObject npc = Instantiate(NPCprefab, randPos + gameObject.transform.position, Quaternion.identity);

            EmotionUnit unit = new EmotionUnit(npc);
            unit.npcScript.Team = Team;
            unit.npcScript.leader = gameObject;
            unit.npcScript.leaderScript = this;
            unit.npcScript.ManagerScript = ManagerScript;

            EmotionArmy.Add(unit);
            ManagerScript.allUnits.Add(unit);
        }
	}
	
	void Update ()
    {
	}

    private void OnCollisionEnter(Collision collision)
    {
        Speed = Base_velocity;
    }

}
