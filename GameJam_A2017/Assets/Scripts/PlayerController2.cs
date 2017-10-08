using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : Player
{

	float H2Move, V2Move;
	bool facingRight = false;
	bool facingLeft = false;
	bool facingDown = true;
	bool facingUp = false;
	public bool canWalk = true;
	public GameObject textBox;
	public GameObject choiceBox;
	public GameObject prefabChoice;

	void Awake () {
	}

    // Use this for initialization
    void Start()
	{
		setAnim ();
		GameManager.Instance.player2 = this;
		nbChoices = CharacterSelect.Instance.GetDifficulty();
		TypeChange (CharacterSelect.Instance._player2);
    }

    // Update is called once per frame
    void FixedUpdate()
	{

		if (!canWalk) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
			return;
		}
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

	public void choiceSetup(int cat, int val) {
		setupChoice (cat, val);
	}
}
