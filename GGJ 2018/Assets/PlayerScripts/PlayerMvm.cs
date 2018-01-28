using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMvm : MonoBehaviour {

	public GameManagerScript ManagerScript;

    public GameObject NPCprefab;
	
    Vector2 velocity;
    Vector2 velocity_p2;
    private Rigidbody2D rigiBody;
    public bool Attack;
    public string Team;
    public float attackRng;
    public int health;
    private Vector2 movementVector;
    private Vector2 movementP2Vect;
    private Vector2 direction = Vector2.zero;
    public int player_no;
    public float acc;
    public float joyStickAccel;

    public float cooldown = 0f;

    public List<EmotionUnit> EmotionArmy;
    public Color color;

    public List<Sprite> sprites;

    void Start ()
    {
        Attack = false;
        rigiBody = GetComponent<Rigidbody2D>();
		
		// Spawn Emotion Army
        EmotionArmy = new List<EmotionUnit>();

        ColorMe();

        for (int i = 0; i < 5; i++)
        {
            Vector3 randPos = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), -1);

            while(randPos.magnitude < 1f)
            {
                randPos = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), -1);
            }

            GameObject npc = Instantiate(NPCprefab, randPos + gameObject.transform.position, Quaternion.identity);

            EmotionUnit unit = new EmotionUnit(npc, this);
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
        Movement();
    }

    private void OnCollisionEnter(Collision collision)
    {
    }

    private void Movement()
    {
        movementVector.y = Input.GetAxis("LeftJoystickX");
        movementVector.x = Input.GetAxis("LeftJoystickY");

        movementP2Vect.y = Input.GetAxis("LeftJoystickX_2");
        movementP2Vect.x = Input.GetAxis("LeftJoystickY_2");

        cooldown -= Time.deltaTime;

        if (player_no == 1)
        {
            //Player 1
            if (Input.GetButtonDown("X") && player_no == 1 && cooldown <= 0f)
            {
                Debug.Log("Button X works for player 1");
                Attack = true;
                cooldown = 1.0f;
            }
            Vector2 pos = transform.position;
            rigiBody.AddForce(rigiBody.velocity.normalized * acc);
            rigiBody.AddForce(new Vector2(movementVector.y, -movementVector.x) * joyStickAccel);
        }

        if (player_no == 2)
        {
            //Player 2
            if (Input.GetButtonDown("X_2") && player_no == 2 && cooldown <= 0f)
            {
                Debug.Log("Button X works for player 2");
                Attack = true;
                cooldown = 1.0f;
            }
            rigiBody.AddForce(rigiBody.velocity.normalized * acc);
            rigiBody.AddForce(new Vector2(movementP2Vect.y, -movementP2Vect.x) * joyStickAccel);
        }

    }

    private void ColorMe()
    {
        if (Team != "None")
        {
            switch (Team)
            {
                case "Anger":
                    GetComponent<SpriteRenderer>().sprite = sprites[0];
                    color = Color.red;
                    break;
                case "Love":
                    GetComponent<SpriteRenderer>().sprite = sprites[1];
                    color = new Color(1.0f, 0.7f, 0.7f);
                    break;
                case "Madness":
                    GetComponent<SpriteRenderer>().sprite = sprites[2];
                    color = new Color(1.0f, 0.2f, 1.0f);
                    break;
                case "Happiness":
                    GetComponent<SpriteRenderer>().sprite = sprites[3];
                    color = Color.green;
                    break;
                case "Sadness":
                    GetComponent<SpriteRenderer>().sprite = sprites[4];
                    color = Color.blue;
                    break;
            }
        }
        else
        {
            color = Color.grey;
        }
    }
}
