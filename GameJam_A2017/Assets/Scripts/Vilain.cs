using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vilain : MonoBehaviour {


	int strikes = 0;
	int wins = 0;
	//int playerChoice = 0;
	bool available = true;
	public House curHouse;
	public GameObject win;
	public GameObject strike;
	public GameObject tie;
	PlayerController1 p1;
	PlayerController2 p2;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		switch (Random.Range(0,3)) {
		case 0:
			anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ("hanzo");
			break;

		case 1:
			anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ("Vilain");
			break;

		case 2:
			anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ("Vilain2");
			break;

		case 3:
			anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ("Vilain3");
			break;

		default:
			print ("Ce type n'existe pas!");
			return;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
    {
		if (available) {
			Debug.Log ("j'te touche");
			GameObject oth = other.gameObject;
			bool dial;
			p1 = oth.GetComponent<PlayerController1> ();
			p2 = oth.GetComponent<PlayerController2> ();
			if (p1 == null) {
				dial = !p2.inDialogue;
			} else {
				dial = !p1.inDialogue;
			}
			if (dial) {
				available = false;
				if (p1 == null) {
					p2.fightSp.SetActive (true);
					p2.inDialogue = true;
					p2.fight = true;
					p2.curOpponent = this;
				} else {
					p1.fightSp.SetActive (true);
					p1.inDialogue = true;
					p1.fight = true;
					p1.curOpponent = this;
				}
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
					p2.fightSp.SetActive (false);
					p2.fight = false;
					p2.curOpponent = null;
					p2.waitVilain = false;
					p2.inDialogue = false;
					p2.Victoire ();
				}
			} else {
				p1.points += (curHouse.points/2);
				p1.fightSp.SetActive (false);
				p1.fight = false;
				p1.curOpponent = null;
				p1.waitVilain = false;
				p1.inDialogue = false;
				p1.Victoire ();
			}
			curHouse.end (false);
		} else if (strikes >= 3){
			if (p1 == null) {
				if (p2 != null) {
					p2.fightSp.SetActive (false);
					p2.fight = false;
					p2.curOpponent = null;
					p2.waitVilain = false;
					p2.inDialogue = false;
				}
			} else {
				p1.fightSp.SetActive (false);
				p1.fight = false;
				p1.curOpponent = null;
				p1.waitVilain = false;
				p1.inDialogue = false;
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
