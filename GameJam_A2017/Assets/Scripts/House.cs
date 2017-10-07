using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

	int Type = 1;
	public int posClient;
	bool disponible = true;
	//private Timer time;


	// Use this for initialization
	void Start () {
		Map.Instance.addHouses (this);
		typeDefine (Type);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void typeDefine (int t) {
		switch (t) {
		case 0: 
			gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("Pauvre");
				break;
		case 1: 
			gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("moyen");
				break;
		case 2: 
			gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("Luxe");
				break;
		case 3: 
			gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("RAF");
				break;
		}	
	}

	public void clientComing () {
		disponible = false;
	}
}
