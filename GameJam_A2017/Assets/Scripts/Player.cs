using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float maxSpeed = 10f;
    public int playerType;
    public int nbChoices = 4;
    public bool getThrough = false;

    // Use this for initialization
    void Start () {
        switch (playerType)
        {
            case 0:
                maxSpeed = 15f;
                break;

            case 1:
                getThrough = true;
                break;

            case 2:
                nbChoices = 5;
                break;
            
            default:
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
