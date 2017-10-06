using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1: MonoBehaviour {

    public float maxSpeed = 10f;
    bool facingRight = true;
    bool facingLeft = false;
    bool facingDown = false;
    bool facingUp = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float Hmove = Input.GetAxis("Horizontal");
        float Vmove = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(Hmove * maxSpeed, Vmove * maxSpeed);

        if (Hmove > 0)
        {
            facingRight = true;
            facingLeft = false;
            facingDown = false;
            facingUp = false;
        }

        if (Hmove < 0)
        {
            facingRight = false;
            facingLeft = true;
            facingDown = false;
            facingUp = false;
        }

        if (Vmove > 0)
        {
            facingRight = false;
            facingLeft = false;
            facingDown = false;
            facingUp = true;
        }

        if (Vmove < 0)
        {
            facingRight = false;
            facingLeft = false;
            facingDown = true;
            facingUp = false;
        }
    }
}
