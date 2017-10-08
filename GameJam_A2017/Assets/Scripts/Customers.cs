using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customers : MonoBehaviour {

	int type;
	public House curHouse;

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
		Debug.Log ("Mada mada");
		GameObject oth = other.gameObject;
		int val = Random.Range (0, 2);
		curHouse.time.Switch();
		PlayerController1 p1 = oth.GetComponent<PlayerController1> ();
		if (p1 == null) {
			PlayerController2 p2 = oth.GetComponent<PlayerController2> ();
			p2.canWalk = false;
			textBoxManagerAdpated txt = gameObject.GetComponent<textBoxManagerAdpated> ();
			txt.textBox = p1.textBox;
			gameObject.GetComponent<textBoxManagerAdpated> ().EnableTextBox();
			p2.curhouse = curHouse;
			p2.choiceSetup(txt.categorie[val], txt.valeurLigne[val]);
		} else {
			p1.canWalk = false;
			textBoxManagerAdpated txt = gameObject.GetComponent<textBoxManagerAdpated> ();
			txt.textBox = p1.textBox;
			gameObject.GetComponent<textBoxManagerAdpated> ().EnableTextBox();
			p1.curhouse = curHouse;
			p1.choiceSetup(txt.categorie[val], txt.valeurLigne[val]);
		}
	}
}
