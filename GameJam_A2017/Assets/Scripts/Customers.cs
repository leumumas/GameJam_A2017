﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customers : MonoBehaviour {

	int type;
	public House curHouse;
	bool available = true;

	// Use this for initialization
	void Start () {
		Object [] obSr = Resources.LoadAll("NPC_SpriteSheet");
		Sprite sr = (Sprite)obSr[Random.Range(1,6)];
		gameObject.GetComponent<SpriteRenderer> ().sprite = sr;
		type = Random.Range (0,3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (available) {
			Debug.Log ("Mada mada");
			bool dial;
			GameObject oth = other.gameObject;
			int val = Random.Range (0, 2);
			PlayerController1 p1 = oth.GetComponent<PlayerController1> ();
			PlayerController2 p2 = oth.GetComponent<PlayerController2> ();
			if (p1 == null) {
				dial = !p2.inDialogue;
			} else {
				dial = !p1.inDialogue;
			}
			if (dial) {
				available = false;
				if (p1 == null) {
					p2.canWalk = false;
					p2.inDialogue = true;
					textBoxManagerAdpated txt = gameObject.GetComponent<textBoxManagerAdpated> ();
					txt.fastButton = KeyCode.Joystick2Button1;
					txt.textBox = p2.textBox;
					gameObject.GetComponent<textBoxManagerAdpated> ().EnableTextBox ();
					p2.curhouse = curHouse;
					p2.choiceSetup (txt.categorie [val], txt.valeurLigne [val]);
				} else {
					p1.canWalk = false;
					p1.inDialogue = true;
					textBoxManagerAdpated txt = gameObject.GetComponent<textBoxManagerAdpated> ();
					txt.fastButton = KeyCode.Joystick1Button1;
					txt.textBox = p1.textBox;
					gameObject.GetComponent<textBoxManagerAdpated> ().EnableTextBox ();
					p1.curhouse = curHouse;
					p1.choiceSetup (txt.categorie [val], txt.valeurLigne [val]);
				}
				curHouse.time.Switch ();
			}
		}
	}
}
