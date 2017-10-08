using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float maxSpeed = 10f;
    public int HP = 10;
    public int attack = 2;
    public int playerType = 0;
    public int nbChoices = 7;
	public int points = 0;
    public bool getThrough = false;
	public float maxXpos, minXpos, maxYpos, minYpos;
	public Animator anim;
    public Choix choice;
	public House curhouse;
	public Vilain curOpponent;

    // Use this for initialization
    void Start () {
    }

	public void setAnim() {
		anim = GetComponent<Animator>();
		choice = new Choix ();
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
			maxSpeed = 2f;
			anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ("flashy");
                break;

		case 1:
			getThrough = true;
			gameObject.GetComponent<Collider2D> ().isTrigger = true;
			anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ("ombre");
                break;

            case 2:
			nbChoices -= 2;
			anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ("mental");
                break;

            default:
                print("Ce type n'existe pas!");
                return;
        }
    }

    public void HPDecrease(ref int HP)
    {
        HP--;
    }

	public void setupChoice (int cat, int val) {
		choice.setup (cat, val, nbChoices);
	}
}
