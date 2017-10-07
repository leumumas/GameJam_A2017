using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float maxSpeed = 10f;
    public int playerType = 0;
    public int nbChoices = 4;
    public bool getThrough = false;
    public float maxXpos, minXpos, maxYpos, minYpos;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //Typechange, 0:Flash, 1:Get through things, 2:Mentalist
    public void TypeChange(int value)
    {
        playerType = value;
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
                print("Ce type n'existe pas!");
                return;
        }
    }
}
