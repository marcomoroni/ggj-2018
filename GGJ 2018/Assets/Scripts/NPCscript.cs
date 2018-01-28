using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCscript : MonoBehaviour
{
    public GameObject leader;
    public PlayerMvm leaderScript;

    public GameManagerScript ManagerScript;

    public GameObject emitter1;
    public GameObject emitter2;

    public ParticleSystem system1;
    public ParticleSystem system2;

    public Material prefabMat;

    public Material radiusMat;
    public Material emissionMat;

    public List<Texture2D> emission;
    public Texture2D radius;

    public string Team = "None";
    public Color color;

    public float HP = 1f;
    public float Dmg = 20f;
    public float Range = 2f;

    public float speed = 2f;
    public Vector2 vel;

	// Use this for initialization
	void Start ()
    {
        system1 = emitter1.GetComponent<ParticleSystem>();
        system2 = emitter2.GetComponent<ParticleSystem>();

        radiusMat = new Material(prefabMat);
        emissionMat = new Material(prefabMat);

        ChangeSprites();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Team == "None")
        {
            Wander();
        }
        else
        {
            FollowLeader();
            Attack();
        }

        UpdatePos();
	}

    private void LateUpdate()
    {
        if (leaderScript.Attack)
        {
            leaderScript.Attack = false;
        }
    }

    private void Attack()
    {
        if (leaderScript.Attack)
        {
            EmitAttack();

            List<EmotionUnit> enemiesInRange = new List<EmotionUnit>();

            foreach (EmotionUnit eU in ManagerScript.allUnits)
            {
                if (eU.npcScript.Team != Team)
                {
                    Vector2 a = gameObject.transform.position;
                    Vector2 b = eU.npc.transform.position;

                    Vector2 dist = b - a;

                    if (dist.magnitude < Range)
                        enemiesInRange.Add(eU);
                }
            }

            if (enemiesInRange.Count > 0)
            {
                for (int i = 0; i < enemiesInRange.Count; i++)
                {
                    enemiesInRange[i].npcScript.HP -= Dmg;

                    if (enemiesInRange[i].npcScript.HP <= 0)
                    {
                        enemiesInRange[i].npcScript.Team = Team;
                        enemiesInRange[i].npcScript.leader = leader;
                        enemiesInRange[i].npcScript.leaderScript = leaderScript;
                        enemiesInRange[i].npcScript.HP = 100f;
                        enemiesInRange[i].leader.EmotionArmy.Remove(enemiesInRange[i]);

                        enemiesInRange[i].leader = leaderScript;
                        enemiesInRange[i].leader.EmotionArmy.Add(enemiesInRange[i]);

                        enemiesInRange[i].npcScript.ChangeSprites();
                    }
                }
            }
        }
    }

    private void EmitAttack()
    {
        ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
        emitParams.startSize = 0.2f;
        emitParams.startColor = color;

        system1.Emit(emitParams, 1);

        for (int i = 0; i < 4; i++)
        {
            ParticleSystem.EmitParams emitParams2 = new ParticleSystem.EmitParams();
            emitParams2.startSize = 0.6f;

            float randX = Random.Range(-1f, 1f);
            float randY = Random.Range(-0.5f, 0.5f);

            float rVel = Random.Range(0.8f, 2f);

            Vector3 v = new Vector3(0f, rVel, 0f);

            emitParams2.velocity = v;
            emitParams2.position = new Vector3(randX, randY, -1f);

            system2.Emit(emitParams2, 1);
        }
    }

    private void FollowLeader()
    {
        Vector2 a = gameObject.transform.position;
        Vector2 b = leader.transform.position;

        Vector2 AtoB = b - a;

        vel = AtoB;
    }

    // Npc wanders around the arena
    private void Wander()
    {

    }

    private void UpdatePos()
    {
        Vector2 pos = gameObject.transform.position;
        pos += vel.normalized * speed * Time.deltaTime;
        gameObject.transform.position = pos;
    }

    public void ChangeSprites()
    {
        radiusMat.SetTexture("_MainTex", radius);

        if (Team != "None")
        {
            switch (Team)
            {
                case "Anger":
                    emissionMat.SetTexture("_MainTex", emission[0]);
                    color = Color.red;
                    break;
                case "Love":
                    emissionMat.SetTexture("_MainTex", emission[1]);
                    color = new Color(1.0f, 0.7f, 0.7f);
                    break;
                case "Madness":
                    emissionMat.SetTexture("_MainTex", emission[2]);
                    color = new Color(1.0f, 0.2f, 1.0f);
                    break;
                case "Happiness":
                    emissionMat.SetTexture("_MainTex", emission[3]);
                    color = Color.green;
                    break;
                case "Sadness":
                    emissionMat.SetTexture("_MainTex", emission[4]);
                    color = Color.blue;
                    break;
                default:
                    emissionMat.SetTexture("_MainTex", emission[0]);
                    break;
            }
        }
        else
        {
            color = Color.grey;
        }

        GetComponent<SpriteRenderer>().color = color;

        emitter1.GetComponent<ParticleSystemRenderer>().material = radiusMat;
        emitter2.GetComponent<ParticleSystemRenderer>().material = emissionMat;
    }
}
