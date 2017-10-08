using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController1: Player {

    float H1Move, V1Move;
	bool facingRight = false;
    bool facingLeft = false;
    bool facingDown = true;
	bool facingUp = false;
	public bool canWalk = true;
	public bool fight = false;
	public bool waitVilain = false;
	public GameObject textBox;
	public GameObject choiceBox;
	public GameObject prefabChoice;
	public GameObject fightSp;
	private List<GameObject> choiceList = new List<GameObject> ();
	List<string> curChoice = new List<string>();
	List<bool> curAnswer = new List<bool>();
	int strike;
	int option = 0;

    public Text txtScoreBox;

	void Awake () {
	}

	// Use this for initialization
	void Start () {
		setAnim ();
		GameManager.Instance.player1 = this;
		nbChoices = CharacterSelect.Instance.GetDifficulty();
		TypeChange (CharacterSelect.Instance._player1);

        txtScoreBox.text = "Score: " + points + "K";

		//int type = CharacterSelect.Instance._player1;
		//TypeChange (type);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (fight) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
			if (Input.GetKeyDown (KeyCode.Joystick1Button2) && !waitVilain) {
				waitVilain = true;
				curOpponent.Shifumi (0);
			}
			if (Input.GetKeyDown (KeyCode.Joystick1Button3) && !waitVilain) {
				waitVilain = true;
				curOpponent.Shifumi (1);
			}
			if (Input.GetKeyDown (KeyCode.Joystick1Button1) && !waitVilain) {
				waitVilain = true;
				curOpponent.Shifumi (2);
			}
			return;
		}
		if (!canWalk) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
			if (Input.GetKeyDown (KeyCode.Joystick1Button4))
				option--;
			if (Input.GetKeyDown (KeyCode.Joystick1Button5))
				option++;
			if (option < 0)
				option = nbChoices - 1;
			else if (option > nbChoices - 1)
				option = 0;
			Debug.Log(option + " option");
			for (int i = 0; i < nbChoices; i++) {
				Color c = choiceList [i].GetComponent<Image> ().material.color;
				if (i == option ) {
					c.a = 0.5f;
					choiceList [i].GetComponentInChildren<Image> ().color = c;
				}
				else {
					c.a = 1.0f;
					choiceList [i].GetComponentInChildren<Image> ().color = c;
				}
			}
			if(Input.GetKeyDown(KeyCode.Joystick1Button0)) {
				if (curAnswer [option] == true) {
					points += curhouse.points;
					curhouse.end (false);
					choiceBox.SetActive (false);
					textBox.SetActive (false);
					canWalk = true;
					inDialogue = false;
					for (int i = 0; i < nbChoices; i++) {
						Destroy (choiceList [i]);
					}
					Victoire ();
				} else {
					strike++;
					Sprite sr = Resources.Load ("WindowWrong") as Sprite;
					choiceList [option].GetComponentInChildren<Image> ().sprite = sr;
					if (strike >= 3) {
						curhouse.lose ();
						choiceBox.SetActive (false);
						textBox.SetActive (false);
						canWalk = true;
						inDialogue = false;
						for (int i = 0; i < nbChoices; i++) {
							Destroy (choiceList [i]);
						}
					}
				}
			}
			return;
		}

		txtScoreBox.text = "Score: " + points + "K";

        //Player 1
        H1Move = Input.GetAxis("Player1_axisX");
        V1Move = Input.GetAxis("Player1_axisY");
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
