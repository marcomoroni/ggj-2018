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

	void Start ()
    {
        Attack = false;
	}
	
	void Update ()
    {
	}

    private void OnCollisionEnter(Collision collision)
    {
        Speed = Base_velocity;
    }

}
