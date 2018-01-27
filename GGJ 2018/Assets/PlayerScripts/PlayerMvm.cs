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
    public int joystick_numb;
    public string joystickString;
    Vector2 movementDir;


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
        joystickString = joystick_numb.ToString();
    }

    private void Movement()
    {
        movementVector.y = Input.GetAxis("LeftJoystickX");
        movementVector.x = Input.GetAxis("LeftJoystickY");

            if (Input.GetButton("X" + joystickString))
            {
                Debug.Log("Button X works");
            }
            //if two parts of the bool are bigger than 0 (so player is using joystick to move) bool is true
        bool isWalking = (Mathf.Abs(movementVector.y) + Mathf.Abs(movementVector.x)) > 0;
        Vector3 movement = new Vector3(movementVector.y, movementVector.x, 0) * Time.deltaTime;
        if (isWalking)
        {
            transform.position += movement * Base_velocity;
        }

    }

}
