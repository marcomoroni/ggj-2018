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
        Speed = Base_velocity;
        joystickString = joystick_numb.ToString();
    }

    private void Movement()
    {
        movementVector.x = Input.GetAxis("LeftJoystickX");
        movementVector.y = Input.GetAxis("LeftJoystickY");

            if (Input.GetButton("X" + joystickString))
            {
                Debug.Log("Button X works");
            }


    }

}
