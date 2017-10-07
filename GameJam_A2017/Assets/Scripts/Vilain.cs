using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vilain : MonoBehaviour {

    public int HP, attack;

	// Use this for initialization
	void Start () {
        HP = 10;
        attack = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D Player)
    {
        Debug.Log("j'te touche");
    }
}
