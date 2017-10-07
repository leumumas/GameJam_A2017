using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

	int Type = 1;
	public int posClient;
	bool disponible = true;
	public GameObject prefabCustomer;
	GameObject customer;
	int points;
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
		Object [] obSr = Resources.LoadAll("Land_SpriteSheet");
		Sprite sr = null;
		switch (t) {
		case 0: 
			sr = (Sprite)obSr [3];
			points = 1;
				break;
		case 1: 
			sr = (Sprite)obSr[2];
			points = 2;
				break;
		case 2: 
			sr = (Sprite)obSr[1];
			points = 4;
				break;
		case 3: 
			sr = (Sprite)obSr[0];
			points = 6;
				break;
		}	
		gameObject.GetComponent<SpriteRenderer> ().sprite = sr;
	}

	public void clientComing () {
		disponible = false;
		gameObject.GetComponent<SpriteRenderer> ().color = Color.blue;
		Vector3 posFinal = new Vector3();
		switch (posClient) {
		case 0: 
			posFinal = new Vector3(0f,1.1f,0f);
			break;
		case 1: 
			posFinal = new Vector3(1.1f,0f,0f);
			break;
		case 2: 
			posFinal = new Vector3(0f,-1.1f,0f);
			break;
		case 3: 
			posFinal = new Vector3(-1.1f,0f,0f);
			break;
		}
		customer = Instantiate (prefabCustomer, (gameObject.transform.localPosition + posFinal), Quaternion.identity);
		customer.transform.parent = gameObject.transform;
		Timer time = gameObject.GetComponent<Timer> ();
		time.Switch ();
	}

	public void end(bool timeOut) {
		if (timeOut) {
			Destroy (gameObject);
			Map.Instance.chooseHouse ();
		}
	}
}
