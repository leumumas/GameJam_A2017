using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customers : MonoBehaviour {

	int type;

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
	}
}
