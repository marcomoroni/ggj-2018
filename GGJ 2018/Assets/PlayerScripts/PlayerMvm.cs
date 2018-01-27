using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMvm : MonoBehaviour {

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

    void Start ()
    {
        Attack = false;
        rigiBody = GetComponent<Rigidbody2D>();
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
        

        if (player_no == 1)
        {
            //Player 1
            if (Input.GetButton("X") && player_no ==1)
            {
                Debug.Log("Button X works for player 1");
                Attack = true;
            }
            Vector2 pos = transform.position;
            rigiBody.AddForce(rigiBody.velocity * acc);
            rigiBody.AddForce(new Vector2(movementVector.y, -movementVector.x));
        }

        if (player_no == 2)
        {
            //Player 2
            if (Input.GetButton("X_2") && player_no == 2)
            {
                Debug.Log("Button X works for player 2");
                Attack = true;
            }
            rigiBody.AddForce(rigiBody.velocity * acc);
            rigiBody.AddForce(new Vector2(movementP2Vect.y, -movementP2Vect.x));
        }

    }

}
