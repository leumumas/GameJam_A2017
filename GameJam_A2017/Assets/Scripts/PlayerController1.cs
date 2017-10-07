using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1: Player {

    float H1Move, V1Move;
	bool facingRight = false;
    bool facingLeft = false;
    bool facingDown = true;
	bool facingUp = false;
	Animator anim;

	void Awake () {
	}

	// Use this for initialization
	void Start () {
		GameManager.Instance.player1 = this;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //Player 1
        H1Move = Input.GetAxis("Player1_axisX");
        V1Move = Input.GetAxis("Player1_axisY");
		Debug.Log (V1Move);
        GetComponent<Rigidbody2D>().velocity = new Vector2(H1Move * maxSpeed, V1Move * maxSpeed);

        //Facing direction
        if (H1Move > 0)
        {
            facingRight = true;
            facingLeft = false;
            facingDown = false;
            facingUp = false;
        }

        if (H1Move < 0)
        {
            facingRight = false;
            facingLeft = true;
            facingDown = false;
            facingUp = false;
        }

        if (V1Move > 0)
        {
            facingRight = false;
            facingLeft = false;
            facingDown = false;
            facingUp = true;
        }

        if (V1Move < 0)
        {
            facingRight = false;
            facingLeft = false;
            facingDown = true;
            facingUp = false;
        }

       
        

        //Position clamping
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minXpos, maxXpos), Mathf.Clamp(transform.position.y, minYpos, maxYpos));

		anim.SetBool ("FacingUp", facingUp);
		anim.SetBool ("FacingDown", facingDown);
		anim.SetBool ("FacingRight", facingRight);
		anim.SetBool ("FacingLeft", facingLeft);
    }

    //Get directions
    bool Right()
    {
        return facingRight;
    }

    bool Left()
    {
        return facingLeft;
    }

    bool Up()
    {
        return facingUp;
    }

    bool Down()
    {
        return facingDown;
    }
}
