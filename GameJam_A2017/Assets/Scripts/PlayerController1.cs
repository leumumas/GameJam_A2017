using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public float maxSpeed = 10f;
    bool facingRight = true;
    bool facingLeft = false;
    bool facingDown = false;
    bool facingUp = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float Hmove = Input.GetAxis("Horizontal");
        float Vmove = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(Hmove * maxSpeed, Vmove * maxSpeed);
	}
}
