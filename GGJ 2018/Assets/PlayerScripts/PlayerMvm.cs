using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMvm : MonoBehaviour {

    public float Base_velocity;
    private Rigidbody2D rigiBody;
    public bool Attack;
    public string Team;
    public float Speed;
    public float attackRng;
    public int health;
    private Vector2 movementVector;
    public int player_no;


    void Start ()
    {
        Base_velocity = 5f;
        Attack = false;
        rigiBody = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        Movement();

	}

    private void OnCollisionEnter(Collision collision)
    {
        Speed = Base_velocity;
    }

    private void Movement()
    {
        movementVector.y = Input.GetAxis("LeftJoystickX");
        movementVector.x = Input.GetAxis("LeftJoystickY");

        if (player_no == 1)
        {
            //Player 1
            if (Input.GetButton("X") && player_no ==1)
            {
                Debug.Log("Button X works for player 1");
            }
            //if two parts of the bool are bigger than 0 (so player is using joystick to move) bool is true
            bool isWalking = (Mathf.Abs(movementVector.y) + Mathf.Abs(movementVector.x)) > 0;
            Vector3 movement = new Vector3(movementVector.y, movementVector.x, 0) * Time.deltaTime;
            if (isWalking)
            {
                transform.position += movement * Base_velocity;
            }
        }

        if (player_no == 2)
        {
            //Player 2

            if (Input.GetButton("X_2") && player_no == 2)
            {
                Debug.Log("Button X works for player 2");
            }
        }
    }

}
