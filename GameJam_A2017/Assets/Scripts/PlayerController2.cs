using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	private List<GameObject> choiceList = new List<GameObject> ();
	List<string> curChoice = new List<string>();
	List<bool> curAnswer = new List<bool>();
	int strike;
	int option = 0;

    public Text txtScoreBox;

	void Awake () {
	}

    // Use this for initialization
    void Start()
	{
		setAnim ();
		GameManager.Instance.player2 = this;
		nbChoices = CharacterSelect.Instance.GetDifficulty();
		TypeChange(CharacterSelect.Instance._player2);

		txtScoreBox.text = "Score: " + points + "K";
    }

    // Update is called once per frame
	void FixedUpdate() {

		if (!canWalk) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
			if (Input.GetKeyDown (KeyCode.JoystickButton4))
				option--;
			if (Input.GetKeyDown (KeyCode.JoystickButton5))
				option++;
			if (option < 0)
				option = nbChoices - 1;
			else if (option > nbChoices - 1)
				option = 0;
			Debug.Log(option + " option");
			for (int i = 0; i < nbChoices; i++) {
				Color c = choiceList [i].GetComponent<Image> ().material.color;
				c.a = 0.5f;
				if (i == option)
					choiceList [i].GetComponentInChildren<Image> ().color = c;
				else {
					c.a = 1.0f;
					choiceList [i].GetComponentInChildren<Image> ().color = c;
				}
			}
			if(Input.GetKeyDown(KeyCode.JoystickButton0)) {
				if (curAnswer [option] == true) {
					points += curhouse.points;
					curhouse.end (false);
					choiceBox.SetActive (false);
					textBox.SetActive (false);
					canWalk = true;
					for (int i = 0; i < nbChoices; i++) {
						Destroy (choiceList [i]);
					}
					if (points >= GameManager.Instance.victoryCondition)
						GameManager.Instance.endGame (1);
				} else {
					strike++;
					choiceList [option].GetComponentInChildren<Image> ().color = Color.red;
					if (strike >= 3) {
						curhouse.end (true);
						choiceBox.SetActive (false);
						textBox.SetActive (false);
						canWalk = true;
						for (int i = 0; i < nbChoices; i++) {
							Destroy (choiceList [i]);
						}
					}
				}
			}
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

		txtScoreBox.text = "Score: " + points + "K";

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
		choiceList.Clear ();
		curAnswer.Clear ();
		curChoice.Clear ();
		setupChoice (cat, val);
		choiceBox.SetActive (true);
		for (int i = 0; i < nbChoices; i++) {
			GameObject individualChoice = Instantiate (prefabChoice, (gameObject.transform.localPosition), Quaternion.identity);
			individualChoice.transform.SetParent(choiceBox.transform);
			individualChoice.transform.localScale = new Vector3 (1, 1, 1);
			int rnd = Random.Range (0, choice.choice.Count);
			individualChoice.GetComponentInChildren<Text>().text = choice.choice[rnd];
			curChoice.Add (choice.choice[rnd]);
			choice.choice.RemoveAt (rnd);
			curAnswer.Add (choice.goodAnswer [rnd]);
			choice.goodAnswer.RemoveAt (rnd);
			choiceList.Add (individualChoice);
		}
		//choiceBox.GetComponent<RectTransform>().position += new Vector3(0f, 1f, 0f);
		strike = 0;
	}
}
