using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vilain : MonoBehaviour {


	int strikes = 0;
	int wins = 0;
	int playerChoice = 0;
	bool available = true;
	public House curHouse;
	public GameObject win;
	public GameObject strike;
	public GameObject tie;
	PlayerController1 p1;
	PlayerController2 p2;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
    {
		if (available) {
			available = false;
			Debug.Log ("j'te touche");
			GameObject oth = other.gameObject;
			p1 = oth.GetComponent<PlayerController1> ();
			if (p1 == null) {
				p2 = oth.GetComponent<PlayerController2> ();
				if (p2 != null) {
					p2.fight = true;
					p2.curOpponent = this;
				}
			} else {
				p1.fight = true;
				p1.curOpponent = this;
			}
		}
	}

	public void Shifumi(int playerChoice)
	{
		int vilainChoice = Random.Range(0,2);
		//Player choisi kekchose
		switch (playerChoice) {
		case 0:
			switch (vilainChoice) {
			case 0:
				print ("Roche vs. Roche, round nulle!");
				tie.SetActive (true);
				break;

			case 1:
				print ("Roche vs. Papier, le vilain gagne le round!");
				strike.SetActive (true);
				strikes++;
				break;

			case 2:
				print ("Roche vs. Ciseaux, vous gagnez le round!");
				win.SetActive (true);
				wins++;
				break;

			default:
				print ("Dafuq kossé que t'essaye de faire lo?!?!?!");
				return;
			}
			break;

		case 1:
			switch (vilainChoice) {
			case 0:
				print ("Papier vs. Roche, vous gagnez le round!");
				win.SetActive (true);
				wins++;
				break;

			case 1:
				print ("Papier vs. Papier, round nulle!");
				tie.SetActive (true);
				break;

			case 2:
				print ("Papier vs. Ciseaux, vous perdez le round!");
				strike.SetActive (true);
				strikes++;
				break;

			default:
				print ("Dafuq kossé que t'essaye de faire lo?!?!?!");
				return;
			}
			break;

		case 2:
			switch (vilainChoice) {
			case 0:
				print ("Ciseaux vs. Roche, vous perdez le round!");
				strike.SetActive (true);
				strikes++;
				break;

			case 1:
				print ("Ciseaux vs. Papier, vous gagnez le round!");
				win.SetActive (true);
				wins++;
				break;

			case 2:
				print ("Ciseaux vs. Ciseaux, round nulle!");
				tie.SetActive (true);
				break;

			default:
				print ("Dafuq kossé que t'essaye de faire lo?!?!?!");
				return;
			}
			break;

		default:
			print ("Dafuq kossé que t'essaye de faire lo?!?!?!");
			return;
		}
		StartCoroutine(waiting());
		if (wins >= 3) {
			if (p1 == null) {
				if (p2 != null) {
					p2.points += (curHouse.points/2);
					p2.fight = false;
					p2.curOpponent = null;
					p2.waitVilain = false;
				}
			} else {
				p1.points += (curHouse.points/2);
				p1.fight = false;
				p1.curOpponent = null;
				p1.waitVilain = false;
			}
			curHouse.end (false);
		} else if (strikes >= 3){
			if (p1 == null) {
				if (p2 != null) {
					p2.fight = false;
					p2.curOpponent = null;
					p2.waitVilain = false;
				}
			} else {
				p1.fight = false;
				p1.curOpponent = null;
				p1.waitVilain = false;
			}
			curHouse.lose ();
		}
	}

	IEnumerator waiting() {
		yield return new WaitForSeconds(2f);
		if (p1 == null) {
			if (p2 != null) {
				p2.waitVilain = false;
			}
		} else {
			p1.waitVilain = false;
		}
		strike.SetActive (false);
		win.SetActive (false);
		tie.SetActive (false);
	}
}
