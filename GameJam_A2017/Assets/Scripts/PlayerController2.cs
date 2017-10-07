using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : Player
{

    float H2Move, V2Move;
    bool facingRight = true;
    bool facingLeft = false;
    bool facingDown = false;
    bool facingUp = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Player 2
        H2Move = Input.GetAxis("Player2_axisX");
        V2Move = Input.GetAxis("Player2_axisY");
        GetComponent<Rigidbody2D>().velocity = new Vector2(H2Move * maxSpeed, V2Move * maxSpeed);

        //Facing direction
        if (H2Move > 0)
        {
            facingRight = true;
            facingLeft = false;
            facingDown = false;
            facingUp = false;
        }

        if (H2Move < 0)
        {
            facingRight = false;
            facingLeft = true;
            facingDown = false;
            facingUp = false;
        }

        if (V2Move > 0)
        {
            facingRight = false;
            facingLeft = false;
            facingDown = false;
            facingUp = true;
        }

        if (V2Move < 0)
        {
            facingRight = false;
            facingLeft = false;
            facingDown = true;
            facingUp = false;
        }

        //Position clamping
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minXpos, maxXpos), Mathf.Clamp(transform.position.y, minYpos, maxYpos));
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
